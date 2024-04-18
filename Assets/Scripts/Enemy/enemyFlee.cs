using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class enemyFlee : MonoBehaviour
{
    /*enemyFlee: This script detects if an enemy is within the radius of the player 
                 as well as activating a fleeAI when it is otherwise, it walks around normally 
    
     Thinsg to keep in mind:
        - is it timed?
        - does it need to be turned on once for everyone or just the ones in the radius


    For now:
        - they run away from the player as it gets closer to them if flee mode is activated; 
     */

    private bool isFlee;
    public GameObject player;

    //for fleeing 
    public float detectionRadius; //this distance is for the 'eating' being visible versus not 
    private NavMeshAgent agent;
    public float enemyDistanceRun = 5f;
    public Material fleematerial; //temporary color change when fleeing

    //not fleeing 
    public float roamRadius = 10f;
    public float roamTimer = 5f; //every how many seconds change positions
    private float timer; //temporary variable
    private Vector3 randomDestination;

    private void Start()
    {
        isFlee = false;
        agent = GetComponent<NavMeshAgent>();
        timer = roamTimer;
        SetRandomDestination();

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
        timer -= Time.deltaTime;
        if (timer <= 0f) //when not in fleeing mode, roam around
        {
            SetRandomDestination();
            timer = roamTimer;
        }

        Debug.Log(timer);
        //we will use -1 as the layers for all layers to be included in the navmesh for now 
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

    private void SetRandomDestination()
    {
        randomDestination = RandomSphere(transform.position, roamRadius, -1);
        Debug.Log("New Destination: " + randomDestination);
        agent.SetDestination(randomDestination);
    }

    private Vector3 RandomSphere(Vector3 origin, float dist, int layers) 
    {
        Vector3 dirRand = Random.insideUnitSphere * dist;
        dirRand += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(dirRand, out navHit, dist, layers); 
        return navHit.position;

    }
}
