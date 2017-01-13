using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;

public class FireScript : MonoBehaviour
{
    public GameObject laser;
    public bool canOverheat = true;
    //public bool toggledOverheat;
    float baseFireFreq;
    float fireFreq;

    float lastShot;
    float laserHeat;
    int overheatMax;
    bool overheated;
    Slider overheatSlider;
    bool cooldown;
    bool isHoldingTrigger;

    ObjectPooling laserPool;
    GameObject gameManager;
    AchievementManager achievementManager;
    PublicVariableHandler publicVariableHandler;
    LaserSound laserSound;
    //Toggle overheatToggle;

    GameObject player;

    AudioClip noLevelSound;
    AudioClip level1Sound;
    AudioClip level2Sound;
    AudioClip level3Sound;
    float laserActiveTime;
    float dualLaserActiveTime;
    [HideInInspector]
    public Transform target;
    bool laserPowerActive;
    bool dualLaserActive;
    InputDevice inputDevice;

    Coroutine laserCoroutine;
    Coroutine dualLaserCoroutine;

    IEnumerator Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
        player = GameObject.Find("Player");
        baseFireFreq = publicVariableHandler.playerShootingFrequency;
        fireFreq = baseFireFreq;
        laserActiveTime = publicVariableHandler.laserPickUpActiveTime;
        dualLaserActiveTime = publicVariableHandler.dualLaserPickUpActiveTime;
        overheatMax = publicVariableHandler.laserOverheatMax;
        overheatSlider = publicVariableHandler.overheatSlider;
        overheatSlider.maxValue = overheatMax;
        //overheatToggle = GameObject.Find("OverheatToggle").GetComponent<Toggle>();
        //overheatToggle.onValueChanged.AddListener((value) => ToggleOverheat());
        //toggledOverheat = overheatToggle.isOn;
        //canOverheat = toggledOverheat;

        noLevelSound = publicVariableHandler.normalLaserSound;

        if (GetComponent<LaserSound>() != null)
            laserSound = GetComponent<LaserSound>();

        if (transform.tag == "PowerUpLasers")
        {
            fireFreq = .15f;
            gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(0.05f);
        //overheatToggle.transform.parent.gameObject.SetActive(false);
    }

    void ToggleOverheat()
    {
        //toggledOverheat = overheatToggle.isOn;
        //canOverheat = toggledOverheat;
        if (gameObject.name == "Gun1")
        {
            overheatSlider.value = 0;
            overheatSlider.gameObject.SetActive(canOverheat);
        }
    }

    void FixedUpdate()
    {
        inputDevice = InputManager.ActiveDevice;
        if (laserHeat >= overheatMax)
        {
            overheated = true;
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            isHoldingTrigger = true;
            if (Time.time > lastShot + fireFreq && !overheated)
                Fire();
        }

        if (Input.GetAxis("Fire1") < 0.1f)
        {
            isHoldingTrigger = false;
            if (overheated)
            {
                CallCoroutine("Overheat");
            }
            else
            {
                laserHeat = Mathf.Lerp(laserHeat, 0, 0.07f);
                if (gameObject.name == "Gun1")
                    overheatSlider.value = laserHeat;
            }
        }
    }

    void CallCoroutine(string coroutine)
    {
        StartCoroutine(coroutine);
    }

    void Fire()
    {
        target = null;
        if (laserSound != null)
            laserSound.Shooting();

        lastShot = Time.time;

        if (canOverheat)
        {
            laserHeat++;
            if (gameObject.name == "Gun1")
                overheatSlider.value = laserHeat;
        }

        GameObject obj = laserPool.GetPooledObject();

        if (obj == null)
        {
            return;
        }
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    public void LaserUpgrade()
    {
        if (!laserPowerActive)
        {
            laserPowerActive = true;
            fireFreq = fireFreq / 2;
            // if (laserSound)
            // laserSound.LevelChange(level2Sound);

            laserCoroutine = StartCoroutine(LaserPickUpActive());
        }
        else
        {
            StopCoroutine(laserCoroutine);
            laserCoroutine = StartCoroutine(LaserPickUpActive());
        }
    }

    public void DualLaserUpgrade()
    {
        if (!dualLaserActive)
        {
            dualLaserActive = true;
            foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
            {
                go.SetActive(true);
            }
            //  if (laserSound)
            // laserSound.LevelChange(level3Sound);
            dualLaserCoroutine = StartCoroutine(DualLaserPickUpActive());
        }
        else
        {
            StopCoroutine(dualLaserCoroutine);
            dualLaserCoroutine = StartCoroutine(DualLaserPickUpActive());
        }
    }

    IEnumerator LaserPickUpActive()
    {
        canOverheat = false;
        laserHeat = 0;
        if (gameObject.name == "Gun1")
            overheatSlider.value = laserHeat;
        yield return new WaitForSeconds(laserActiveTime);
        //  if (laserSound)
        //  laserSound.LevelChange(level1Sound);
        fireFreq = fireFreq * 2;
        laserPowerActive = false;
        //if (toggledOverheat)
            canOverheat = true;
    }

    IEnumerator DualLaserPickUpActive()
    {
        laserHeat = 0;
        if (gameObject.name == "Gun1")
            overheatSlider.value = laserHeat;
        yield return new WaitForSeconds(dualLaserActiveTime);

        if (laserSound)
            laserSound.LevelChange();

        foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
        {
            go.SetActive(false);
        }
        // if (laserSound)
        //   laserSound.LevelChange(level2Sound);

        dualLaserActive = false;
    }

    IEnumerator Overheat()
    {
        if (!cooldown)
        {
            cooldown = true;
            for (int i = 0; i < overheatMax; i++)
            {
                if (!isHoldingTrigger)
                {
                    laserHeat--;
                    if (gameObject.name == "Gun1")
                        overheatSlider.value = laserHeat;
                    yield return new WaitForSeconds(0.07f);
                }
                else
                {
                    i--;
                    yield return new WaitForSeconds(0f);
                }
            }
            overheated = false;
            cooldown = false;
        }
    }
}