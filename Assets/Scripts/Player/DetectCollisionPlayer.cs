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
            enteredWeeds.Raise();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weeds"))
        {
            leftWeeds.Raise();
        }
    }
}
