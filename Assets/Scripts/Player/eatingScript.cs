using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatingScript : MonoBehaviour
{

    /*
     Attach this script to the 'Player', this script allows the detection of an object tagged with the appropriate type,
     The edible object type must have a 'eatController' script and particleSystem attached to it.
     */
    public float detectionDistance = 10f; // Maximum distance for detection
    private GameObject currentEnemy = null; // Reference to the current enemy
    private eatController eatContLocal;

    private void Update()
    {
        if(LookEnemy() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player is looking at the enemy and pressed 'Space'!");

            if(currentEnemy != null){

                Debug.Log("Activated the eating controller");
                eatContLocal.Activate();                                                            //also possibly add in sound?? 
            }
        }

        else
        {
            if (currentEnemy != null)
            {
                currentEnemy = null; // Reset the reference
            }
        }
    }


    //This function checks to see if the player is currently looking at at enemy
    private bool LookEnemy() {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            // Check if the raycast hits an enemy
            if (hit.collider.CompareTag("biggerDuck")) //add mpre later on depending on how many duck types we have
            {
                // Store the reference to the enemy
                currentEnemy = hit.collider.gameObject;
                if(currentEnemy == null)
                {
                    Debug.Log("curr enemy is null");
                }
                // Get the EnemyController script attached to the enemy
                eatContLocal = currentEnemy.GetComponent<eatController>();
                if(eatContLocal == null)
                {
                    Debug.Log("eatContLocal is null");
                }
                return true;
            }
        }
        return false;
    }
}
