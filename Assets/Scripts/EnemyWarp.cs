using UnityEngine;
using System.Collections;

public class EnemyWarp : MonoBehaviour
{
    UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController aeroplaneController;
    UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAiControl aeroplaneAIControl;
    UnityStandardAssets.Utility.WaypointProgressTracker wayPointTracker;
    GameObject player;
    public float minSpeed;
    public float maxSpeed;
    float speed;

    void Start()
    {
        aeroplaneController = GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController>();
        aeroplaneAIControl = GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAiControl>();
        wayPointTracker = GetComponent<UnityStandardAssets.Utility.WaypointProgressTracker>();

        aeroplaneController.enabled = false;
        aeroplaneAIControl.enabled = false;
        wayPointTracker.enabled = false;
        player = GameObject.Find("Player");
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if(transform.position.z - player.transform.position.z > 2750)
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            aeroplaneController.enabled = true;
            aeroplaneAIControl.enabled = true;
            wayPointTracker.enabled = true;
        }
    }
}

