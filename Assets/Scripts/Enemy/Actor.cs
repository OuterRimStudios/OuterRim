using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float speed;
    public float recalcDelay;
    public float enemyZClamp;
    public float enemyXPos;
    public float centerX;
    public float centerY;
    public float centerZ;
    public float maneuverRadius;
    public float maneuverRadiusMin;
    public float maneuverRadiusMax;

    public GameObject player;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

    public bool DebugMode;

    private enum State
    {
        IDLE,
        MOVING,
        MANEUVER,
        STRAFE,
        CROSS,
    }

    private State state = State.MOVING;

    GameObject playerTarget;

    private float OldTime = 0;
    //private float checkTime = 0;
    private float elapsedTime = 0;
    private float maneuverSpeed;
    private float strafeSpeed;
    private float lerpSpeed;
    private float maneuverTimer;
    private float maneuverAngle;
    private float _centerX;
    private float _centerY;
    private float _centerZ;
    private float m_speed_multi = 40;

    private bool onNode = true;
    private bool recalculating;
    private bool startManeuver;
    private bool hasChosenAction;
    private bool ceasedFire = true;
    private bool maneuverLeft;
    private bool hasChosenDirection;

    private Vector3 m_target = new Vector3(0, 0, 0);
    private Vector3 currNode;

    private int nodeIndex;
    private int randomInt;

    private List<Vector3> path = new List<Vector3>();

    private NodeControl control;
    private WaveHandler _waveHandler;

    private Transform lookAtPoint;      //The point that the ship looks at during the maneuver state
    GameObject gameManager;
    PublicVariableHandler publicVariableHandler;
    private void Awake()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        control = (NodeControl)gameManager.GetComponent(typeof(NodeControl));
        _waveHandler = gameManager.GetComponent<WaveHandler>();
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        maneuverSpeed = publicVariableHandler.maneuverSpeed;
        strafeSpeed = publicVariableHandler.strafeSpeed;

        _centerX = centerX + Random.Range(-500, 500);
        _centerY = centerY;
        _centerZ = centerZ + Random.Range(-500, 500);

        gun1 = GetComponent<EnemyStoreVariables>().gun1;
        gun2 = GetComponent<EnemyStoreVariables>().gun2;
        gun3 = GetComponent<EnemyStoreVariables>().gun3;

        lookAtPoint = GetComponent<EnemyStoreVariables>().lookAtPoint;
    }

    private void Start()
    {
        enemyZClamp = Random.Range(700f, 1000f);
        enemyXPos = Random.Range(-250f, 250f);
        lerpSpeed = Random.Range(0.5f, 1f);
        maneuverRadius = Random.Range(maneuverRadiusMin, maneuverRadiusMax);

        player = GameObject.Find("Player");
        playerTarget = GameObject.Find("PlayerTarget");
        gameManager = GameObject.Find("GameManager");

        switch (transform.parent.name)
        {
            case "FirstEnemyShips":
                speed = gameManager.GetComponent<PublicVariableHandler>().enemy1Speed;
                break;
            case "SecondEnemyShips":
                print("secondenemyships");
                speed = gameManager.GetComponent<PublicVariableHandler>().enemy2Speed;
                break;
            case "ThirdEnemyShips":
                speed = gameManager.GetComponent<PublicVariableHandler>().enemy3Speed;
                break;
            case "FourthEnemyShips":
                print("fourthenemyships");
                speed = gameManager.GetComponent<PublicVariableHandler>().enemy4Speed;
                break;
        }
    }

    private void OnDisable()
    {
        startManeuver = true;
        hasChosenDirection = false;
        hasChosenAction = false;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (playerTarget.transform.position.z + enemyZClamp >= transform.position.z)      //if enemy is near player
        {
            if (!hasChosenAction)
            {
                hasChosenAction = true;
                randomInt = Random.Range(0, 2);

                if (randomInt == 0)
                {
                    ChangeState(State.MANEUVER);
                }
                else if (randomInt == 1)
                {
                    ChangeState(State.STRAFE);
                }
                else if (randomInt == 2)
                {
                    ChangeState(State.CROSS);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (maneuverTimer >= ((5 * Mathf.PI) / 3))
        {
            ChangeState(State.MOVING);
            hasChosenAction = false;
            maneuverTimer = 0;
        }

        if (elapsedTime > OldTime)
        {
            switch (state)
            {
                case State.IDLE:
                    break;

                case State.MOVING:
                    OldTime = elapsedTime + 0.01f;

                    if (ceasedFire)
                    {
                        ceasedFire = false;
                        gun1.GetComponent<Enemy1Fire>().canFire = true;
                        gun2.GetComponent<Enemy1Fire>().canFire = true;
                        gun3.GetComponent<Enemy1Fire>().canFire = false;
                    }

                    transform.LookAt(playerTarget.transform);

                    transform.Translate(Vector3.forward * speed * Time.deltaTime);

                    //if (elapsedTime > checkTime)
                    //{
                    //    checkTime = elapsedTime + 1;
                    //    SetTarget();
                    //}

                    //if (path != null)
                    //{
                    //    if (onNode)
                    //    {
                    //        onNode = false;
                    //        if (nodeIndex < path.Count)
                    //            currNode = path[nodeIndex];
                    //    }
                    //    else
                    //        MoveToward();
                    //}
                    break;

                case State.MANEUVER:
                    OldTime = elapsedTime + 0.01f;

                    if (!ceasedFire)
                    {
                        ceasedFire = true;
                        gun1.GetComponent<Enemy1Fire>().canFire = false;
                        gun2.GetComponent<Enemy1Fire>().canFire = false;
                        gun3.GetComponent<Enemy1Fire>().canFire = false;
                    }

                    transform.LookAt(lookAtPoint);

                    maneuverTimer += Time.deltaTime;
                    maneuverAngle = maneuverTimer;

                    centerX += playerTarget.transform.position.x;
                    centerY += playerTarget.transform.position.y;
                    centerZ += playerTarget.transform.position.z;

                    if (transform.position.x > playerTarget.transform.position.x && !hasChosenDirection)
                    {
                        hasChosenDirection = true;
                        maneuverLeft = false;
                    }
                    else if (transform.position.x < playerTarget.transform.position.x && !hasChosenDirection)
                    {
                        hasChosenDirection = true;
                        maneuverLeft = true;
                    }

                    if (maneuverLeft && hasChosenDirection)
                    {
                        lookAtPoint.position = new Vector3(-centerX + (Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 3)));
                        //Maneuver to the left of the player
                        transform.position = Vector3.Lerp(transform.position, lookAtPoint.position, Time.deltaTime * maneuverSpeed);
                    }
                    else if (!maneuverLeft && hasChosenDirection)
                    {
                        lookAtPoint.position = new Vector3(centerX + -(Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 3)));
                        //Maneuver to the right of the player
                        transform.position = Vector3.Lerp(transform.position, lookAtPoint.position, Time.deltaTime * maneuverSpeed);
                    }

                    centerX = _centerX;
                    centerY = _centerY;
                    centerZ = _centerZ;

                    break;

                case State.STRAFE:
                    OldTime = elapsedTime + 0.01f;

                    if (transform.position.x < playerTarget.transform.position.x && transform.position.y < playerTarget.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position + new Vector3(-100f, -100f, -1000f), Time.deltaTime * strafeSpeed);
                    }
                    else if (transform.position.x < playerTarget.transform.position.x && transform.position.y > playerTarget.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position + new Vector3(-100f, 100f, -1000f), Time.deltaTime * strafeSpeed);
                    }
                    else if (transform.position.x > playerTarget.transform.position.x && transform.position.y > playerTarget.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position + new Vector3(100f, 100f, -1000f), Time.deltaTime * strafeSpeed);
                    }
                    else if (transform.position.x > playerTarget.transform.position.x && transform.position.y < playerTarget.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position + new Vector3(100f, -100f, -1000f), Time.deltaTime * strafeSpeed);
                    }

                    if (transform.position.z > playerTarget.transform.position.z + 400)
                    {
                        transform.LookAt(playerTarget.transform);
                        gun3.transform.LookAt(playerTarget.transform);
                        gun3.GetComponent<Enemy1Fire>().canFire = true;
                    }
                    else if (transform.position.z <= playerTarget.transform.position.z + 400)
                    {
                        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                        gun3.transform.LookAt(playerTarget.transform);

                        if (transform.position.z < playerTarget.transform.position.z - 200)
                        {
                            transform.position = gameManager.GetComponent<WaveManager>().ChooseLocation();
                            //switch (transform.name)
                            //{
                            //    case "Enemy1":
                            //        _waveHandler.firstEnemyCount--;
                            //        gameObject.SetActive(false);
                            //        break;
                            //    case "Enemy2":
                            //        _waveHandler.secondEnemyCount--;
                            //        gameObject.SetActive(false);
                            //        break;
                            //    case "Enemy3":
                            //        _waveHandler.thirdEnemyCount--;
                            //        gameObject.SetActive(false);
                            //        break;
                            //    case "Enemy4":
                            //        _waveHandler.fourthEnemyCount--;
                            //        gameObject.SetActive(false);
                            //        break;
                            //}
                        }
                    }

                    break;

                case State.CROSS:

                    OldTime = elapsedTime + 0.01f;

                    if (!ceasedFire)
                    {
                        ceasedFire = true;
                        gun1.GetComponent<Enemy1Fire>().canFire = false;
                        gun2.GetComponent<Enemy1Fire>().canFire = false;
                        gun3.GetComponent<Enemy1Fire>().canFire = false;
                    }

                    //transform.LookAt (lookAtPoint);

                    maneuverTimer += Time.deltaTime;
                    maneuverAngle = maneuverTimer;

                    centerX += playerTarget.transform.position.x;
                    centerY += playerTarget.transform.position.y;
                    centerZ += playerTarget.transform.position.z;

                    if (transform.position.x < playerTarget.transform.position.x && !hasChosenDirection)
                    {
                        hasChosenDirection = true;
                        maneuverLeft = false;
                    }
                    else if (transform.position.x > playerTarget.transform.position.x && !hasChosenDirection)
                    {
                        hasChosenDirection = true;
                        maneuverLeft = true;
                    }

                    if (maneuverLeft && hasChosenDirection)
                    {
                        lookAtPoint.position = new Vector3(-centerX + (Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 3)));
                        //Maneuver to the left of the player
                        transform.position = Vector3.Lerp(transform.position, lookAtPoint.position, Time.deltaTime * maneuverSpeed);
                    }
                    else if (!maneuverLeft && hasChosenDirection)
                    {
                        lookAtPoint.position = new Vector3(centerX + -(Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 3)));
                        //Maneuver to the right of the player
                        transform.position = Vector3.Lerp(transform.position, lookAtPoint.position, Time.deltaTime * maneuverSpeed);
                    }

                    centerX = _centerX;
                    centerY = _centerY;
                    centerZ = _centerZ;
                    break;
            }
        }
    }


    private void MoveToward()
    {
        if (DebugMode)
        {
            for (int i = 0; i < path.Count - 1; ++i)
            {
                Debug.DrawLine((Vector3)path[i], (Vector3)path[i + 1], Color.white, 0.01f);
            }
        }

        Vector3 newPos = transform.position;

        float Xdistance = newPos.x - currNode.x;

        if (Xdistance < 0)
        {
            Xdistance -= Xdistance * 2;
        }

        float Ydistance = newPos.z - currNode.z;

        if (Ydistance < 0)
        {
            Ydistance -= Ydistance * 2;
        }

        if ((Xdistance < 0.1 && Ydistance < 0.1) && m_target == currNode) //Reached target
        {
            ChangeState(State.IDLE);
        }
        else if (Xdistance < 0.1 && Ydistance < 0.1)
        {
            nodeIndex++;
            onNode = true;
        }

        /***Move toward waypoint***/
        Vector3 motion = currNode - newPos;
        motion.Normalize();
        newPos += motion * (speed * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
    }

    private void SetTarget()
    {
        path = control.Path(transform.position, m_target);
        nodeIndex = 0;
        onNode = true;
    }

    public void MoveOrder(Vector3 pos)
    {
        m_target = pos;
        SetTarget();
        ChangeState(State.MOVING);
    }

    private void ChangeState(State newState)
    {
        state = newState;
    }

    private IEnumerator RecalculateMove()
    {
        if (!recalculating)
        {
            recalculating = true;
            yield return new WaitForSeconds(recalcDelay);
            MoveOrder(player.transform.position);
            recalculating = false;
        }
    }

    private void CallRecalculateMove()
    {
        StartCoroutine(RecalculateMove());
    }
}