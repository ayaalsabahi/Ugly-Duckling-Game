using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionPlayer : MonoBehaviour
{
    [Header("Events")]
    public GameEvent leftWeeds;
    public GameEvent enteredWeeds; //possibly add more types of weeds


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weeds"))
        {
            Debug.Log("Entered weeds");
            enteredWeeds.Raise();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weeds"))
        {
            Debug.Log("Exit weeds");
            leftWeeds.Raise();
        }
    }
}
