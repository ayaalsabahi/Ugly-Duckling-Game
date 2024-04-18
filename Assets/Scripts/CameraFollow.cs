using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;
    //public float smoothing = 10f;
    //Vector3 offset;

    //private void Start()
    //{
    //    offset = transform.position - target.position;
    //}

    //// Update is called once per frame
    //void LateUpdate()
    //{
        
    //    Vector3 targetCamPos = target.position + offset;
    //    transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    //}


    //temporarily updating the camera
    public Transform playerTransform;
    public float smoothing = 5f;
    public Vector3 offset = new Vector3(0f, 2f, -20f); //ffset to position the camera behind the player

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
