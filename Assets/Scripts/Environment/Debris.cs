using UnityEngine;
using System.Collections.Generic;

public class Debris : MonoBehaviour 
{
    public Vector3 chosenDirection;
    public List<Vector3> directions;
    public float destroyTime;
    public float rotationSpeed;

    void Start()
    {
        Vector3 forward = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;

        directions.Add(forward);
        directions.Add(back);
        directions.Add(left);
        directions.Add(right);

        chosenDirection = directions[Random.Range(0, directions.Count)];
    }

    void Update()
    {
        //transform.Rotate(chosenDirection * Time.deltaTime * rotationSpeed);
    }

}
