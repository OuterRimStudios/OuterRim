using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float maxTurnAngle;
    [HideInInspector]
    public float horizontalTurnAngle;
    public float moveX;
    public float moveY;
    public float moveZ;

    public float clampX;
    public float clampY;

    public bool invertVertical;
    //InputDevice inputDevice;
	GameObject gameManager;
    Controls _controls;
    string saveData;

    void OnEnable()
    {
        _controls = Controls.CreateWithDefaultBindings();
    }

    void OnDisable()
    {
        _controls.Destroy();
    }

    void Start()
    {
       gameManager = GameObject.Find("GameManager");
       playerSpeed = gameManager.GetComponent<PublicVariableHandler>().playerSpeed;
       maxTurnAngle = gameManager.GetComponent<PublicVariableHandler>().playerRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //inputDevice = InputManager.ActiveDevice;
        horizontalTurnAngle = -(_controls.Move.X * Time.deltaTime * playerSpeed * 50) * 20;
        horizontalTurnAngle = Mathf.Clamp(horizontalTurnAngle, -maxTurnAngle, maxTurnAngle);
        moveX = _controls.Move.X * Time.deltaTime * playerSpeed;

        if (_controls.Move.X != 0)       // && transform.rotation.z > -45 && transform.rotation.z < 45
        {
            transform.Rotate((Vector3.forward * horizontalTurnAngle * Time.deltaTime) * 7);
            ClampRotation(-maxTurnAngle, maxTurnAngle, 0);
        }

        if (_controls.Move.X == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);
        }

        if (invertVertical)           //inverted vertical movement
        {
            moveY = -(_controls.Move.Y * Time.deltaTime * (playerSpeed / 2));
        }
        else if (!invertVertical)     //normal vertical movement
        {
            moveY = _controls.Move.Y * Time.deltaTime * (playerSpeed / 2);
        }

        transform.position += new Vector3(moveX, moveY, moveZ);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX), Mathf.Clamp(transform.position.y, -clampY, clampY), transform.position.z);
    }

    void ClampRotation(float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        //Get the angle of the z axis and rotate it up side down
        float z = transform.rotation.eulerAngles.z - clampAroundAngle;

        z = WrapAngle(z);

        //Move range to [-180, 180]
        z -= 180;

        //Clamp to desired range
        z = Mathf.Clamp(z, minAngle, maxAngle);

        //Move range back to [0, 360]
        z += 180;

        //Set the angle back to the transform and rotate it back to right side up
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z + clampAroundAngle);
    }

    //Make sure angle is within 0,360 range
    float WrapAngle(float angle)
    {
        //If its negative rotate until its positive
        while (angle < 0)
            angle += 360;

        //If its to positive rotate until within range
        return Mathf.Repeat(angle, 360);
    }

    void SaveBindings()
    {
        saveData = _controls.Save();
        PlayerPrefs.SetString("Bindings", saveData);
    }


    void LoadBindings()
    {
        if (PlayerPrefs.HasKey("Bindings"))
        {
            saveData = PlayerPrefs.GetString("Bindings");
            _controls.Load(saveData);
        }
    }
}