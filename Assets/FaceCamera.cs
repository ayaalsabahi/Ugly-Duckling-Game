using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{ 

        void Update()
        {
            // Get the direction from the object to the main camera
            Vector3 directionToCamera = Camera.main.transform.position - transform.position;

            // Make the object look towards the camera (only rotate around the y-axis)
            transform.LookAt(transform.position + directionToCamera, Vector3.up);
        }

    
}
