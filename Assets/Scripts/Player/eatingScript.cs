using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatingScript : MonoBehaviour
{

    /*
     Attach this script to the 'Player', this script allows the detection of an object tagged with the appropriate type,
     The edible object type must have a 'eatController' script and particleSystem attached to it.
     */
    public float detectionDistance; // Maximum distance for detection

    private List<GameObject> currentEnemies = new List<GameObject>(); // List to store references to current enemies
    private List<eatController> eatContLocals = new List<eatController>(); // List to store references to eatController components

    private void Update()
    {
        if (LookEnemy() && Input.GetKeyDown(KeyCode.Space))
        {
            

            foreach (GameObject enemy in currentEnemies)
            {
                
                int index = currentEnemies.IndexOf(enemy);

                if (currentEnemies.Count != eatContLocals.Count) Debug.Log("two lists are not the same length in eating script");

                if (index < eatContLocals.Count) //sanity check 
                {
                    Debug.Log("Small bite here");
                    eatContLocals[index].Activate(); // Activate eatController for the current enemy
                }
                // Add sound activation code here if needed
            }
        }
        else
        {
            // Clear the lists if no enemies are detected
            currentEnemies.Clear();
            eatContLocals.Clear();
        }
    }


    //This function checks to see if the player is currently looking at at enemy
    private bool LookEnemy()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionDistance);
        bool foundEnemy = false;

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("biggerDuck") || collider.CompareTag("EnemyRun")) // add more tags later depending on how many ducks we have
            {
                foundEnemy = true;
                if (!currentEnemies.Contains(collider.gameObject))
                {
                    currentEnemies.Add(collider.gameObject);
                }  // this adds the game object to our list 

                eatController eatContLocal = collider.gameObject.GetComponent<eatController>();
                if (eatContLocal != null)
                {
                    eatContLocals.Add(eatContLocal);
                }

            }
        }

        return foundEnemy; //tells us if we have enemies or not
    }

     
}