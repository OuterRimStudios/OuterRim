using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementManager : MonoBehaviour
{    
    public RectTransform achievementContainer;
    public RectTransform achievementCap;

    public Text achievement;

    public Image badge;

    public float containerStartingX;
    public float containerEndingX;
    public float capStartingX;
    public float capEndingX;
    public float uiWaitTime;
    public float lerpSpeed;
    
    PlayerScore playerScore;
    PlayerCollision playerCollision;
    PickUpManager pickUpManager;

    GameObject gameManager;
    GameObject player;
    GameObject playerCollider;

    int gameTime;
    int totalEnemiesDied;
    int totalLaserShots;
    int enemiesHit;

    bool uiActive;
    bool waiting;
    bool atEndPos;
    bool canDeactivate;

    public Vector3 containerStartPos;
    public Vector3 containerEndPos;
    public Vector3 capStartPos;
    public Vector3 capEndPos;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
        playerCollider = GameObject.FindGameObjectWithTag("PlayerCollider");
        playerCollision = playerCollider.GetComponent<PlayerCollision>();
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();

        containerStartPos = achievementContainer.anchoredPosition;
        //containerEndPos = new Vector3(containerEndingX, achievementContainer.anchoredPosition.y, 0f);
        capStartPos = achievementCap.anchoredPosition;
        //capEndPos = new Vector3(capEndingX, achievementCap.anchoredPosition.y, 0f);
    }

    void Update()
    {
        gameTime = (int)Time.timeSinceLevelLoad;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAchievements();            
        }

        //Score Achievements
        switch (playerScore.score)
        {
            case 10000:
                //print("You earned 10,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement1") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement1", 1);
                    PlayerPrefs.SetInt("Claw Red", 1);
                    achievement.text = "You earned 10,000 points!";
                    CallWait();
                }
                break;

            case 25000:
                //print("You earned 100,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement2") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement2", 1);
                    PlayerPrefs.SetInt("Claw Pink", 1);
                    achievement.text = "You earned 25,000 points!";
                    CallWait();
                }
                break;

            case 50000:
                //print("You earned 100,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement3") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement3", 1);
                    PlayerPrefs.SetInt("Claw Purple", 1);
                    achievement.text = "You earned 50,000 points!";
                    CallWait();
                }
                break;

            case 100000:
                //print("You earned 250,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement4") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement4", 1);
                    PlayerPrefs.SetInt("Claw Green", 1);
                    achievement.text = "You earned 100,000 points!";
                    CallWait();
                }
                break;

            case 150000:
                //print("You earned 500,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement5") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement5", 1);
                    PlayerPrefs.SetInt("Claw Orange", 1);
                    achievement.text = "You earned 150,000 points!";
                    CallWait();
                }
                break;

            case 200000:
                //print("You earned 1,000,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement6") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement6", 1);
                    PlayerPrefs.SetInt("Claw Yellow", 1);
                    achievement.text = "You earned 200,000 points!";
                    CallWait();
                }
                break;

            case 250000:
                //print("You earned 1,000,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement7") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement7", 1);
                    PlayerPrefs.SetInt("Claw White", 1);
                    achievement.text = "You earned 250,000 points!";
                    CallWait();
                }
                break;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Stayed alive for x minutes!
        switch (gameTime)
        {
            case 1:
                //print("Welcome to the Outer Rim! Stayed alive for 1 second!");
                if (PlayerPrefs.GetInt("StayAlive1") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive1", 1);
                    PlayerPrefs.SetInt("Death Adder Blue", 1);
                    achievement.text = "Welcome to the Outer Rim!";
                    CallWait();
                }
                break;

            case 60:
                //print("Stayed alive for 1 minute!");
                if (PlayerPrefs.GetInt("StayAlive2") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive2", 1);
                    PlayerPrefs.SetInt("Death Adder Red", 1);
                    achievement.text = "Stayed alive for 1 minute!";
                    CallWait();
                }
                break;

            case 300:
                //print("Stayed alive for 5 minutes!");
                if (PlayerPrefs.GetInt("StayAlive3") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive3", 1);
                    PlayerPrefs.SetInt("Death Adder Pink", 1);
                    achievement.text = "Stayed alive for 5 minutes!";
                    CallWait();
                }
                break;

            case 600:
                //print("Stayed alive for 10 minutes!");
                if (PlayerPrefs.GetInt("StayAlive4") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive4", 1);
                    PlayerPrefs.SetInt("Death Adder Purple", 1);
                    achievement.text = "Stayed alive for 10 minutes!";
                    CallWait();
                }
                break;

            case 900:
                //print("Stayed alive for 15 minutes!");
                if (PlayerPrefs.GetInt("StayAlive5") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive5", 1);
                    PlayerPrefs.SetInt("Death Adder Yellow", 1);
                    achievement.text = "Stayed alive for 15 minutes!";
                    CallWait();
                }
                break;

            case 1200:
                //print("Stayed alive for 20 minutes!");
                if (PlayerPrefs.GetInt("StayAlive6") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive6", 1);
                    PlayerPrefs.SetInt("Death Adder Green", 1);
                    achievement.text = "Stayed alive for 20 minutes!";
                    CallWait();
                }
                break;

            case 1500:
                //print("Stayed alive for 25 minutes!");
                if (PlayerPrefs.GetInt("StayAlive7") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive7", 1);
                    PlayerPrefs.SetInt("Death Adder Orange", 1);
                    achievement.text = "Stayed alive for 25 minutes!";
                    CallWait();
                }
                break;

            case 1800:
                //print("Stayed alive for 30 minutes!");
                if (PlayerPrefs.GetInt("StayAlive8") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive8", 1);
                    PlayerPrefs.SetInt("Death Adder White", 1);
                    achievement.text = "Stayed alive for 30 minutes!";
                    CallWait();
                }
                break;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //No damage in x amount of minutes!
           if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 30)
        {
            //print("No damage in 30 seconds!");
            if (PlayerPrefs.GetInt("NoDamage1") == 0)
            {
                PlayerPrefs.SetInt("NoDamage1", 1);
                PlayerPrefs.SetInt("Organic Green", 1);
                achievement.text = "So far so good! No damage in 30 seconds!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 60)
        {
            //print("No damage in 1 min!");
            if (PlayerPrefs.GetInt("NoDamage2") == 0)
            {
                PlayerPrefs.SetInt("NoDamage2", 1);
                PlayerPrefs.SetInt("Organic Yellow", 1);
                achievement.text = "No damage in 1 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 300)
        {
            //print("No damage in 5 min!");
            if (PlayerPrefs.GetInt("NoDamage3") == 0)
            {
                PlayerPrefs.SetInt("NoDamage3", 1);
                PlayerPrefs.SetInt("Organic Red", 1);
                achievement.text = "No damage in 5 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 600)
        {
            //print("No damage in 10 min!");
            if (PlayerPrefs.GetInt("NoDamage4") == 0)
            {
                PlayerPrefs.SetInt("NoDamage4", 1);
                PlayerPrefs.SetInt("Organic Blue", 1);
                achievement.text = "No damage in 10 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 900)
        {
            //print("No damage in 15 min!");
            if (PlayerPrefs.GetInt("NoDamage5") == 0)
            {
                PlayerPrefs.SetInt("NoDamage5", 1);
                PlayerPrefs.SetInt("Organic Pink", 1);
                achievement.text = "No damage in 15 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 1200)
        {
            //print("No damage in 20 min!");
            if (PlayerPrefs.GetInt("NoDamage6") == 0)
            {
                PlayerPrefs.SetInt("NoDamage6", 1);
                PlayerPrefs.SetInt("Organic Purple", 1);
                achievement.text = "No damage in 20 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 1500)
        {
            //print("No damage in 25 min!");
            if (PlayerPrefs.GetInt("NoDamage7") == 0)
            {
                PlayerPrefs.SetInt("NoDamage7", 1);
                PlayerPrefs.SetInt("Organic Orange", 1);
                achievement.text = "No damage in 25 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 1800)
        {
            //print("No damage in 30 min!....... You are a god.");
            if (PlayerPrefs.GetInt("NoDamage8") == 0)
            {
                PlayerPrefs.SetInt("NoDamage8", 1);
                PlayerPrefs.SetInt("Organic White", 1);
                achievement.text = "You are a god! No damage in 30min.";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Stay alive with 1 health for x amount of time.
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 30)
        {
            //print("At 1 health for 30 seconds!");
            if (PlayerPrefs.GetInt("OneHealth1") == 0)
            {
                PlayerPrefs.SetInt("OneHealth1", 1);
                PlayerPrefs.SetInt("TriDrone Orange", 1);
                achievement.text = "Stay calm and collected. At 1 health for 30 seconds!";
                CallWait();
            }
        }

        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 60)
        {
            //print("At 1 health for 1 min!");
            if (PlayerPrefs.GetInt("OneHealth2") == 0)
            {
                PlayerPrefs.SetInt("OneHealth2", 1);
                PlayerPrefs.SetInt("TriDrone Yellow", 1);
                achievement.text = "At 1 health for 1 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 300)
        {
            //print("At 1 health for 5 min!");
            if (PlayerPrefs.GetInt("OneHealth3") == 0)
            {
                PlayerPrefs.SetInt("OneHealth3", 1);
                PlayerPrefs.SetInt("TriDrone Pink", 1);
                achievement.text = "At 1 health for 5 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 600)
        {
            //print("At 1 health for min!");
            if (PlayerPrefs.GetInt("OneHealth4") == 0)
            {
                PlayerPrefs.SetInt("OneHealth4", 1);
                PlayerPrefs.SetInt("TriDrone Purple", 1);
                achievement.text = "At 1 health for 10 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 900)
        {
            //print("At 1 health for 15 min!");
            if (PlayerPrefs.GetInt("OneHealth5") == 0)
            {
                PlayerPrefs.SetInt("OneHealth5", 1);
                PlayerPrefs.SetInt("TriDrone Blue", 1);
                achievement.text = "At 1 health for 15 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 1200)
        {
            //print("At 1 health for 20 min!");
            if (PlayerPrefs.GetInt("OneHealth6") == 0)
            {
                PlayerPrefs.SetInt("OneHealth6", 1);
                PlayerPrefs.SetInt("TriDrone Red", 1);
                achievement.text = "At 1 health for 20 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 1500)
        {
            //print("At 1 health for 25 min!");
            if (PlayerPrefs.GetInt("OneHealth7") == 0)
            {
                PlayerPrefs.SetInt("OneHealth7", 1);
                PlayerPrefs.SetInt("TriDrone Green", 1);
                achievement.text = "At 1 health for 25 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 1800)
        {
            //print("At 1 health for 30 min!");
            if (PlayerPrefs.GetInt("OneHealth8") == 0)
            {
                PlayerPrefs.SetInt("OneHealth8", 1);
                PlayerPrefs.SetInt("TriDrone White", 1);
                achievement.text = "At 1 health for 30 min!";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Weapons fully upgraded

        if (pickUpManager.shieldLevel == 3)
        {
            //print("Shield fully upgraded!!");
            if (PlayerPrefs.GetInt("ShieldUpgraded") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgraded", 1);
                PlayerPrefs.SetInt("Ranger Steel", 1);
                achievement.text = "Shield fully upgraded!!";
                CallWait();
            }
        }

        if (pickUpManager.laserLevel == 3)
        {
            //print("Laser fully upgraded!!");
            if (PlayerPrefs.GetInt("LasersUpgraded") == 0)
            {
                PlayerPrefs.SetInt("LasersUpgraded", 1);
                PlayerPrefs.SetInt("Ranger Copper", 1);
                achievement.text = "Lasers fully upgraded!!";
                CallWait();
            }
        }

        if (pickUpManager.missileLevel == 3)
        {
            //print("Missile fully upgraded!!");
            if (PlayerPrefs.GetInt("MissilesUpgraded") == 0)
            {
                PlayerPrefs.SetInt("MissilesUpgraded", 1);
                PlayerPrefs.SetInt("Ranger Gold", 1);
                achievement.text = "Missiles fully upgraded!!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3)
        {
            //print("All weapons fully upgraded!!");
            if (PlayerPrefs.GetInt("FullyUpgraded") == 0)
            {
                PlayerPrefs.SetInt("FullyUpgraded", 1);
                PlayerPrefs.SetInt("Ranger White", 1);
                achievement.text = "All weapons fully upgraded!!";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Weapons fully leveled for x amount of time

        if (pickUpManager.shieldLevel == 3 && gameTime == 30)
        {
            //print("Shield fully upgraded for 30 seconds!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed1", 1);
                PlayerPrefs.SetInt("Star Wing Pink", 1);
                achievement.text = "Shield fully upgraded for 30 seconds!";
                CallWait();
            }
        }

        if (pickUpManager.shieldLevel == 3 && gameTime == 60)
        {
            //print("Shield fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed2", 1);
                PlayerPrefs.SetInt("Star Wing Blue", 1);
                achievement.text = "Shield fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 300)
        {
            //print("Shield fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed3", 1);
                PlayerPrefs.SetInt("Star Wing Green", 1);
                achievement.text = "Shield fully upgraded for 5 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 600)
        {
            //print("Shield fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed4", 1);
                PlayerPrefs.SetInt("Star Wing Orange", 1);
                achievement.text = "Shield fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 900)
        {
            //print("Shield fully upgraded for 15 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed5") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed5", 1);
                PlayerPrefs.SetInt("Star Wing Yellow", 1);
                achievement.text = "Shield fully upgraded for 15 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 1200)
        {
            //print("Shield fully upgraded for 20 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed6") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed6", 1);
                PlayerPrefs.SetInt("Star Wing Red", 1);
                achievement.text = "Shield fully upgraded for 20 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 1500)
        {
            //print("Shield fully upgraded for 25 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed7") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed7", 1);
                PlayerPrefs.SetInt("Star Wing Purple", 1);
                achievement.text = "Shield fully upgraded for 25 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 1800)
        {
            //print("Shield fully upgraded for 30 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed8") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed8", 1);
                PlayerPrefs.SetInt("Star Wing White", 1);
                achievement.text = "Shield fully upgraded for 30 minutes!";
                CallWait();
            }
        }

        if (pickUpManager.laserLevel == 3 && gameTime == 30)
        {
            //print("Laser fully upgraded for 30 seconds!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed1", 1);
                PlayerPrefs.SetInt("CWing Yellow", 1);
                achievement.text = "Laser fully upgraded for 30 seconds!";
                CallWait();
            }
        }

        if (pickUpManager.laserLevel == 3 && gameTime == 60)
        {
            //print("Laser fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed2", 1);
                PlayerPrefs.SetInt("CWing Purple", 1);
                achievement.text = "Laser fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 300)
        {
            //print("Laser fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed3", 1);
                PlayerPrefs.SetInt("CWing Red", 1);
                achievement.text = "Laser fully upgraded for 5 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 600)
        {
            //print("Laser fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed4", 1);
                PlayerPrefs.SetInt("CWing Orange", 1);
                achievement.text = "Laser fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 900)
        {
            //print("Laser fully upgraded for 15 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed5") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed5", 1);
                PlayerPrefs.SetInt("CWing Pink", 1);
                achievement.text = "Laser fully upgraded for 15 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 1200)
        {
            //print("Laser fully upgraded for 20 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed6") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed6", 1);

                PlayerPrefs.SetInt("CWing Green", 1);
                achievement.text = "Laser fully upgraded for 20 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 1500)
        {
            //print("Laser fully upgraded for 25 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed7") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed7", 1);
                PlayerPrefs.SetInt("CWing Blue", 1);
                achievement.text = "Laser fully upgraded for 25 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 1800)
        {
            //print("Laser fully upgraded for 30 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed8") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed8", 1);
                PlayerPrefs.SetInt("CWing White", 1);
                achievement.text = "Laser fully upgraded for 30 minutes!";
                CallWait();
            }
        }



        if (pickUpManager.missileLevel == 3 && gameTime == 30)
        {
            //print("Missile fully upgraded for 30 seconds!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed1", 1);
                PlayerPrefs.SetInt("Metal Blade Purple", 1);
                achievement.text = "Missile fully upgraded for 30 seconds!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 60)
        {
            //print("Missile fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed2", 1);
                PlayerPrefs.SetInt("Metal Blade Blue", 1);
                achievement.text = "Missile fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 300)
        {
            //print("Missile fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed3", 1);
                PlayerPrefs.SetInt("Metal Blade Green", 1);
                achievement.text = "Missile fully upgraded for 5 minutes!";
                CallWait();
            }

        }
        if (pickUpManager.missileLevel == 3 && gameTime == 600)
        {
            //print("Missile fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed4", 1);
                PlayerPrefs.SetInt("Metal Blade Yellow", 1);
                achievement.text = "Missile fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 900)
        {
            //print("Missile fully upgraded for 15 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed5") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed5", 1);
                PlayerPrefs.SetInt("Metal Blade Pink", 1);
                achievement.text = "Missile fully upgraded for 15 minute!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 1200)
        {
            //print("Missile fully upgraded for 20 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed6") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed6", 1);
                PlayerPrefs.SetInt("Metal Blade Red", 1);
                achievement.text = "Missile fully upgraded for 20 minute!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 1500)
        {
            //print("Missile fully upgraded for 25 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed7") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed7", 1);
                PlayerPrefs.SetInt("Metal Blade Orange", 1);
                achievement.text = "Missile fully upgraded for 25 minute!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 1800)
        {
            //print("Missile fully upgraded for 30 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed8") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed8", 1);
                PlayerPrefs.SetInt("Metal Blade White", 1);
                achievement.text = "Missile fully upgraded for 30 minute!";
                CallWait();
            }
        }

        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 30)
        {
            //print("All weapons fully upgraded for 30 seconds!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed1", 1);
                PlayerPrefs.SetInt("Super Wing Green", 1);
                achievement.text = "All weapons fully upgraded for 30 seconds!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 60)
        {
            //print("All weapons fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed2", 1);
                PlayerPrefs.SetInt("Super Wing Yellow", 1);
                achievement.text = "All weapons fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 300)
        {
           // print("All weapons fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed3", 1);
                PlayerPrefs.SetInt("Super Wing Orange", 1);
                achievement.text = "All weapons fully upgraded for 5 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 600)
        {
            //print("All weapons fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed4", 1);
                PlayerPrefs.SetInt("Super Wing Red", 1);
                achievement.text = "All weapons fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 900)
        {
            //print("All weapons fully upgraded 15 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed5") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed5", 1);
                PlayerPrefs.SetInt("Super Wing Pink", 1);
                achievement.text = "All weapons fully upgraded for 15 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 1200)
        {
            //print("All weapons fully upgraded 20 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed6") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed6", 1);
                PlayerPrefs.SetInt("Super Wing Blue", 1);
                achievement.text = "All weapons fully upgraded for 20 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 1500)
        {
            //print("All weapons fully upgraded 25 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed7") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed7", 1);
                PlayerPrefs.SetInt("Super Wing Purple", 1);
                achievement.text = "All weapons fully upgraded for 25 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 1800)
        {
            //print("All weapons fully upgraded 30 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed8") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed8", 1);
                PlayerPrefs.SetInt("Super Wing White", 1);
                achievement.text = "All weapons fully upgraded for 30 minutes!";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Amount of enemies destroyed!
        switch (totalEnemiesDied)
        {
            case 1:
                //print("You got one! 1 Enemy killed.");
                if (PlayerPrefs.GetInt("KilledEnemy1") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy1", 1);
                    PlayerPrefs.SetInt("Dark Wing Yellow", 1);
                    achievement.text = "You got one! One enemy killed!";
                    CallWait();
                }
                break;

            case 50:
                //print("50 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy2") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy2", 1);
                    PlayerPrefs.SetInt("Dark Wing Orange", 1);
                    achievement.text = "50 enemies killed!";
                    CallWait();
                }
                break;

            case 100:
                //print("100 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy3") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy3", 1);
                    PlayerPrefs.SetInt("Dark Wing Pink", 1);
                    achievement.text = "100 enemies killed!";
                    CallWait();
                }
                break;

            case 250:
                //print("250 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy4") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy4", 1);
                    PlayerPrefs.SetInt("Dark Wing Blue", 1);
                    achievement.text = "250 enemies killed!";
                    CallWait();
                }
                break;

            case 500:
                //print("500 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy5") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy5", 1);
                    PlayerPrefs.SetInt("Dark Wing Green", 1);
                    achievement.text = "500 enemies killed!";
                    CallWait();
                }
                break;

            case 1000:
                //print("1000 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy6") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy6", 1);
                    PlayerPrefs.SetInt("Dark Wing Purple", 1);
                    achievement.text = "1000 enemies killed!";
                    CallWait();
                }
                break;

            case 2500:
                //print("100 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy7") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy7", 1);
                    PlayerPrefs.SetInt("Dark Wing Red", 1);
                    achievement.text = "100 enemies killed!";
                    CallWait();
                }
                break;

            case 5000:
                //print("5000 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy8") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy8", 1);
                    PlayerPrefs.SetInt("Dark Wing White", 1);
                    achievement.text = "5000 enemies killed!";
                    CallWait();
                }
                break;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //How many lasers shot ever.

        switch (totalLaserShots)
        {
            case 100:
                //print("100 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot1") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot1", 1);
                    PlayerPrefs.SetInt("InvisiBlade Red", 1);
                    achievement.text = "100 Lasers shot!";
                    CallWait();
                }
                break;

            case 250:
                //print("500 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot2") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot2", 1);
                    PlayerPrefs.SetInt("InvisiBlade Blue", 1);
                    achievement.text = "250 Lasers shot!";
                    CallWait();
                }
                break;

            case 500:
                //print("500 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot3") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot3", 1);
                    PlayerPrefs.SetInt("InvisiBlade Orange", 1);
                    achievement.text = "500 Lasers shot!";
                    CallWait();
                }
                break;

            case 1000:
                //print("1,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot4") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot4", 1);
                    PlayerPrefs.SetInt("InvisiBlade Purple", 1);
                    achievement.text = "1,000 Lasers shot!";
                    CallWait();
                }
                break;

            case 2500:
                //print("500 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot5") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot5", 1);
                    PlayerPrefs.SetInt("InvisiBlade Green", 1);
                    achievement.text = "2,500 Lasers shot!";
                    CallWait();
                }
                break;

            case 5000:
                //print("5,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot6") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot6", 1);
                    PlayerPrefs.SetInt("InvisiBlade Yellow", 1);
                    achievement.text = "5,000 Lasers shot!";
                    CallWait();
                }
                break;

            case 10000:
                //print("10,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot7") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot7", 1);
                    PlayerPrefs.SetInt("InvisiBlade Pink", 1);
                    achievement.text = "10,000 Lasers shot!";
                    CallWait();
                }
                break;

            case 25000:
                //print("25,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot8") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot8", 1);
                    PlayerPrefs.SetInt("InvisiBlade White", 1);
                    achievement.text = "25,000 Lasers shot!";
                    CallWait();
                }
                break;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------      
        //Meteors destroyed

    }

    //Methods for Enemies Killed.
    public void EnemyDied()
    {
        totalEnemiesDied++;
    }

    //Methods for Lasers Shot.
    public void LaserShot()
    {
        totalLaserShots++;
    }
    //Methods for detecting accuracy
    public void EnemyHit()
    {
        enemiesHit++;
    }

    bool ActivateUI()
    {
        achievementCap.anchoredPosition = Vector3.Lerp(achievementCap.anchoredPosition, capEndPos, Time.deltaTime * lerpSpeed);
        achievementContainer.anchoredPosition = Vector3.Lerp(achievementContainer.anchoredPosition, containerEndPos, Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(achievementCap.anchoredPosition, capEndPos) <= .1f)
        {
            return true;
        }

        return false;
    }

    bool DeactivateUI()
    {
        achievementCap.anchoredPosition = Vector3.Lerp(achievementCap.anchoredPosition, capStartPos, Time.deltaTime * lerpSpeed);
        achievementContainer.anchoredPosition = Vector3.Lerp(achievementContainer.anchoredPosition, containerStartPos, Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(achievementCap.anchoredPosition, capStartPos) <= .1f)
        {
            return true;
        }

        return false;
    }

    void CallWait()
    {
        StartCoroutine(UITimer(uiWaitTime));
    }

    IEnumerator UITimer(float waitTime)
    {
        if (!uiActive)
        {
            uiActive = true;
            yield return new WaitUntil(ActivateUI);
            yield return new WaitForSeconds(waitTime);
            yield return new WaitUntil(DeactivateUI);
            uiActive = false;
        }
    }

    void ResetAchievements()
    {
        print("Reset Achievments");
        PlayerPrefs.SetInt("ScoreAchievement1", 0);
        PlayerPrefs.SetInt("ScoreAchievement2", 0);
        PlayerPrefs.SetInt("ScoreAchievement3", 0);
        PlayerPrefs.SetInt("ScoreAchievement4", 0);
        PlayerPrefs.SetInt("ScoreAchievement5", 0);
        PlayerPrefs.SetInt("ScoreAchievement6", 0);
        PlayerPrefs.SetInt("ScoreAchievement7", 0);
        PlayerPrefs.SetInt("StayAlive1", 0);
        PlayerPrefs.SetInt("StayAlive2", 0);
        PlayerPrefs.SetInt("StayAlive3", 0);
        PlayerPrefs.SetInt("StayAlive4", 0);
        PlayerPrefs.SetInt("StayAlive5", 0);
        PlayerPrefs.SetInt("StayAlive6", 0);
        PlayerPrefs.SetInt("StayAlive7", 0);
        PlayerPrefs.SetInt("StayAlive8", 0);
        PlayerPrefs.SetInt("NoDamage1", 0);
        PlayerPrefs.SetInt("NoDamage2", 0);
        PlayerPrefs.SetInt("NoDamage3", 0);
        PlayerPrefs.SetInt("NoDamage4", 0);
        PlayerPrefs.SetInt("NoDamage5", 0);
        PlayerPrefs.SetInt("NoDamage6", 0);
        PlayerPrefs.SetInt("NoDamage7", 0);
        PlayerPrefs.SetInt("NoDamage8", 0);
        PlayerPrefs.SetInt("OneHealth1", 0);
        PlayerPrefs.SetInt("OneHealth2", 0);
        PlayerPrefs.SetInt("OneHealth3", 0);
        PlayerPrefs.SetInt("OneHealth4", 0);
        PlayerPrefs.SetInt("OneHealth5", 0);
        PlayerPrefs.SetInt("OneHealth6", 0);
        PlayerPrefs.SetInt("OneHealth7", 0);
        PlayerPrefs.SetInt("OneHealth8", 0);
        PlayerPrefs.SetInt("ShieldUpgraded", 0);
        PlayerPrefs.SetInt("LaserUpgraded", 0);
        PlayerPrefs.SetInt("MissileUpgraded", 0);
        PlayerPrefs.SetInt("FullyUpgraded", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed1", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed2", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed3", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed4", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed5", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed6", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed7", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed8", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed1", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed2", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed3", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed4", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed5", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed6", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed7", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed8", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed1", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed2", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed3", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed4", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed5", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed6", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed7", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed8", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed1", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed2", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed3", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed4", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed5", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed6", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed7", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed8", 0);
        PlayerPrefs.SetInt("KilledEnemy1", 0);
        PlayerPrefs.SetInt("KilledEnemy2", 0);
        PlayerPrefs.SetInt("KilledEnemy3", 0);
        PlayerPrefs.SetInt("KilledEnemy4", 0);
        PlayerPrefs.SetInt("KilledEnemy5", 0);
        PlayerPrefs.SetInt("KilledEnemy6", 0);
        PlayerPrefs.SetInt("KilledEnemy7", 0);
        PlayerPrefs.SetInt("KilledEnemy8", 0);
        PlayerPrefs.SetInt("LaserShot1", 0);
        PlayerPrefs.SetInt("LaserShot2", 0);
        PlayerPrefs.SetInt("LaserShot3", 0);
        PlayerPrefs.SetInt("LaserShot4", 0);
        PlayerPrefs.SetInt("LaserShot5", 0);
        PlayerPrefs.SetInt("LaserShot6", 0);
        PlayerPrefs.SetInt("LaserShot7", 0);
        PlayerPrefs.SetInt("LaserShot8", 0);
    }
}