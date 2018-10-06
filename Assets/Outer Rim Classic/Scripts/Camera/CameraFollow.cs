using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    GameObject playerTarget;
    public float cameraSpeed;
    public Vector3 cameraOffset;
    public bool snapMovement;
    
	void Start ()
    {
        player = GameObject.Find("Player");
        playerTarget = GameObject.Find("PlayerTarget");
	}
	void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTarget.transform.position.x + cameraOffset.x, playerTarget.transform.position.y + cameraOffset.y, playerTarget.transform.position.z + cameraOffset.z), Time.deltaTime * cameraSpeed);
    }
}
