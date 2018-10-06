using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterRimStudios
{
    public class OuterRimCamera : MonoBehaviour
    {
        public float speed;
        public Vector3 offset;

        Vector3 velocity;
        Transform player;

        private void Start()
        {
            player = GameObject.Find("Player").transform;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, speed);
        }
    }
}
