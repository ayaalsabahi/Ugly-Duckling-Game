using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class enemyFlee : MonoBehaviour
{
    /*enemyFlee: This script detects if an enemy is within the radius of the player 
                 as well as activating a fleeAI when it is
    
     Thinsg to keep in mind:
        - is it timed?
        - does it need to be turned on once for everyone or just the ones in the radius


    For now:
        - they run away from the player as it gets closer to them if flee mode is activated; 
     */

    public float detectionRadius; //this distance is for the 'eating' being visible versus not 
    private NavMeshAgent agent;
    public float enemyDistanceRun = 5f;
    private bool isFlee = false;
    public GameObject player;
    public Material fleematerial; //temporary color change when fleeing

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isFlee)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if(distance < enemyDistanceRun)
            {
                Vector3 dirToPlayer = transform.position - player.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                agent.SetDestination(newPos);
            }
        }
    }


    //get all the objects that are near me and check if any of the objects nearby is the player
    public void isNear()
    {
        
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
        Debug.Log("flee mode is called");
        isFlee = true;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = fleematerial; //change the color of the duck
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier")) //barrier is where the game objects dissapear 
        {
            Destroy(gameObject);
        }
    }
}
