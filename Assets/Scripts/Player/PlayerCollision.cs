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
    public GameObject damageIndicatorIMG;
    public GameObject meteorExplosionPrefab;

    public int playerHealth;
    public static int fightersDestroyed;
    public static int carriersDestroyed;
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

    ObjectPooling explosionPool1;
    ObjectPooling explosionPool2;
    ObjectPooling explosionPool;

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
        damageIndicatorIMG = GameObject.Find("HitEffect");
        damageIndicatorIMG.SetActive(false);    

        playerHealth = publicVariableHandler.playerHealth;
        healthScore = publicVariableHandler.healthRecoverScore;

        fightersDestroyed = 0;
        carriersDestroyed = 0;

        explosionPool = GameObject.Find("EnemyExplosionPools").GetComponent<ObjectPooling>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (enabled)
        {
            
            if (col.gameObject.tag == "Enemy Laser")
            {
                col.gameObject.SetActive(false);
                StartCoroutine(Immunity());
            }
            else if (col.gameObject.tag == "Carrier")
            {
                playerHealth -= 3;

                if (explosionPool != null)
                {
                    GameObject shipExplosion = explosionPool.GetPooledObject();
                    shipExplosion.transform.position = transform.position;
                    shipExplosion.SetActive(true);
                }
                col.gameObject.SetActive(false);
                CheckHealth();
            }
            else if (col.gameObject.tag == "Enemy")
            {
             //   playerHealth -= 3;
                col.GetComponent<Enemy1Collision>().SpawnEffect("ShipExplosion");
              //  CheckHealth();
            }
        }
    }

    IEnumerator Immunity()
    {
        if (!takingDamage)
        {
            takingDamage = true;
            StartCoroutine(DamageIndicator());
            playerHealth--;

            CheckHealth();
            yield return new WaitForSeconds(.5f);
            takingDamage = false;
        }
    }

    public void AsteroidHit()
    {
        if (enabled)
        {
            playerHealth -= 3;
            CheckHealth();
        }
    }

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

        CheckHealth();
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
        for (int i = 0; i < 10; i++)
        {
            aplh = aplh + .075f;
            if (Time.timeScale >= .1f)
            {
                fadeOut.color = new Color(0, 0, 0, aplh);
                Time.timeScale -= .2f;
            }
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(.25f));
        }

        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            {"waves", gameManager.GetComponent<WaveManager>().waveCount },
            {"score", PlayerPrefs.GetInt("Score") },
            {"fightersDestroyed", fightersDestroyed },
            {"carriersDestroyed", carriersDestroyed },
            {"shipName", PlayerPrefs.GetString("Ship") }
        });
        SceneManager.LoadScene("GameOver");
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(DamageIndicator());
        playerHealth -= amount;

        CheckHealth();
    }
}
