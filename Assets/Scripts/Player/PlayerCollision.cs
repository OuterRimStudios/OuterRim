using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSound;
    public Image healthBar;
    public Sprite[] healthBarSprites;
    //public GameObject healthBar1;
    //public GameObject healthBar2;
    //public GameObject healthBar3;
    //public GameObject lifeImage1;
    //public GameObject lifeImage2;
    public GameObject damageIndicatorIMG;
    public GameObject meteorExplosionPrefab;

    public int playerHealth;
    int healthScore;

    public string gameOverScene;

    public bool shieldActive;

    PlayerScore playerScoreOBJ;

    PickUpManager pickUpManager;
    
    GameObject player;
    GameObject gameManager;
    PublicVariableHandler publicVariableHandler;
    bool takingDamage;
    AudioSource source;
    Image fadeOut;
    float aplh = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScoreOBJ = player.GetComponent<PlayerScore>();

        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        source = gameManager.transform.FindChild("HitSourceManager").GetComponent<AudioSource>();

        fadeOut = publicVariableHandler.fadeOut;
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();

        healthBarSprites = Resources.LoadAll<Sprite>("HealthBarSprites");
        //healthBar1 = GameObject.Find("HealthBar1");
        //healthBar2 = GameObject.Find("HealthBar2");
        //healthBar3 = GameObject.Find("HealthBar3");
        damageIndicatorIMG = GameObject.Find("HitEffect");
        damageIndicatorIMG.SetActive(false);

        //lifeImage1 = publicVariableHandler.shipIMG1;
        //lifeImage2 = publicVariableHandler.shipIMG2;        

        playerHealth = publicVariableHandler.playerHealth;
        healthScore = publicVariableHandler.healthRecoverScore;

        //StartCoroutine(CheckScore());
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy Laser")
        {
            col.gameObject.SetActive(false);
            StartCoroutine(Immunity());
        }
        else if (col.gameObject.tag == "Meteor" || col.gameObject.tag == "Carrier")
        {
            playerHealth -= 3;
            //pickUpManager.LoseLevel();
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            col.gameObject.SetActive(false);
            CheckHealth();
        }
        else if (col.gameObject.tag == "Enemy")
        {
            playerHealth -= 3;
            //pickUpManager.LoseLevel();
            col.GetComponent<Enemy1Collision>().WasDestroyed();
            CheckHealth();
        }
    }

    IEnumerator Immunity()
    {
        if (!takingDamage)
        {
            takingDamage = true;
            StartCoroutine(DamageIndicator());
            playerHealth--;
            //pickUpManager.LoseLevel();

            CheckHealth();
            yield return new WaitForSeconds(.5f);
            takingDamage = false;
        }
    }

    //IEnumerator CheckScore()
    //{
    //    if (playerScoreOBJ.score % healthScore == 0 && playerScoreOBJ.score != 0)
    //    {
    //        playerHealth++;

    //        CheckHealth();
    //        yield return new WaitForSeconds(10f);
    //    }
    //    else
    //    {
    //        CheckHealth();
    //        yield return new WaitForSeconds(0f);
    //    }

    //    StartCoroutine(CheckScore());
    //}

    IEnumerator DamageIndicator()
    {
        source.clip = publicVariableHandler.hitSound;
        source.Play();
        if (!damageIndicatorIMG.activeInHierarchy)
        {
            damageIndicatorIMG.SetActive(true);
            yield return new WaitForSeconds(0.075f);
            damageIndicatorIMG.SetActive(false);
        }
    }

    void CheckHealth()
    {
        if (playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
        else
        {
            healthBar.sprite = healthBarSprites[playerHealth];
            //if (playerHealth % 3 == 0)
            //{
            //    healthBar1.SetActive(true);
            //    healthBar2.SetActive(true);
            //    healthBar3.SetActive(true);
            //}
            //else if (playerHealth % 3 == 2)
            //{
            //    healthBar1.SetActive(true);
            //    healthBar2.SetActive(true);
            //    healthBar3.SetActive(false);
            //}
            //else if (playerHealth % 3 == 1)
            //{
            //    healthBar1.SetActive(true);
            //    healthBar2.SetActive(false);
            //    healthBar3.SetActive(false);
            //}
            //else if (playerHealth % 3 == 4)
            //{
            //    healthBar1.SetActive(false);
            //    healthBar2.SetActive(false);
            //    healthBar3.SetActive(false);
            //}

            //if (playerLives % 3 == 0)
            //{
            //    lifeImage1.SetActive(true);
            //    lifeImage2.SetActive(true);
            //}
            //else if (playerLives % 3 == 2)
            //{
            //    lifeImage1.SetActive(true);
            //    lifeImage2.SetActive(false);
            //}
            //else if (playerLives % 3 == 1)
            //{
            //    lifeImage1.SetActive(false);
            //    lifeImage2.SetActive(false);
            //}
        }        
    }

    public void GainLife()
    {
        switch (playerHealth)
        {
            case 10:
                break;
            case 9:
                playerHealth++;
                break;
            case 8:
                playerHealth += 2;
                break;
            default:
                playerHealth += 3;
                break;
        }
    }

    public static class CoroutineUtil
    {
        public static IEnumerator WaitForRealSeconds(float time)
        {
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + time)
            {
                yield return null;
            }
        }
    }

    IEnumerator GameOver()
    {
        //yield return new WaitUntil(FadeOut);
        for (int i = 0; i < 20; i++)
        {
            aplh = aplh + .075f;
            if (Time.timeScale >= .1f)
            {
                fadeOut.color = new Color(0, 0, 0, aplh);
                Time.timeScale -= .1f;
            }
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(3f));
            Analytics.CustomEvent("gameOver", new Dictionary<string, object>
            {
                {"waves", gameManager.GetComponent<WaveManager>().waveCount },
                {"score", PlayerPrefs.GetInt("Score") },
                {"shipName", PlayerPrefs.GetString("Ship") }
            });
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(DamageIndicator());
        playerHealth -= amount;
        //pickUpManager.LoseLevel();

        CheckHealth();
    }
}
