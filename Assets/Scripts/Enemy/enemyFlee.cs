using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlee : MonoBehaviour
{
    /*enemyFlee: This script detects if an enemy is within the radius of the player 
                 as well as activating a fleeAI when it is
    
     Thinsg to keep in mind:
        - is it timed?
        - does it need to be turned on once for everyone or just the ones in the radius


    For now:
        - they run up to 30s and only as long as they are at a distance away by detection distance 
     */

    public float detectionRadius; //this distance is for the 'eating' being visible versus not 

    

    //get all the objects that are near me and check if any of the objects nearby is the player
    public void isNear()
    {
        Debug.Log("Is near was called");
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        // Loop through all the colliders that intersect with the sphere
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player") && !GameManager.Instance.isHidden) // as well as the object not being hidden 
            {
                fleeMode();
                
            }
        }

       
    }

    private void fleeMode()
    {
        Debug.Log("I am now fleeing");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
