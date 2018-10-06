using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterRimStudios
{
    public class PlayerMovement : Movement
    {
        public float speed;
        public float rotationSpeed;
        public Vector3 turnAngle;

        Rigidbody rb;
        Vector3 direction;

        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody>();
        }

        protected override void Update()
        {
            base.Update();
            Move();
            Rotate();
        }

        protected override void Move()
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            direction.Normalize();
            direction *= speed * Time.deltaTime;
            rb.velocity = direction;
        }

        protected override void Rotate()
        {

            //X Rotation
            float xRotationValue = -Input.GetAxis("Vertical");
            xRotationValue = ClampAngle(xRotationValue, -turnAngle.x, turnAngle.x);
            //--------

            ////X Rotation
            //float yRotationValue = Input.GetAxis("Horizontal");
            //yRotationValue = ClampAngle(yRotationValue, -turnAngle.y, turnAngle.y);
            ////--------

            //Z Rotation
            float zRotationValue = Input.GetAxis("Horizontal");
            zRotationValue = ClampAngle(zRotationValue, -turnAngle.z, turnAngle.z);
            //--------


            Quaternion rotation = Quaternion.Euler(xRotationValue * 50,0, -zRotationValue * 50);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360.0f)
                angle += 360.0f;
            if (angle > 360.0f)
                angle -= 360.0f;
            return Mathf.Clamp(angle, min, max);
        }
    }
}

