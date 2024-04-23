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

    private NavMeshAgent agent;
  
    
    public Transform player;

    [Header("For suspicious")]
    public bool isSuspicous;
    public Material suspiciousMaterial;
    public float suspiciousSpeed; 

    [Header("For fleeing")]
    public float detectionRadius; //this distance is for the 'eating' being visible versus not 
    private bool isFlee;
    public Material fleeMaterial; //temporary color change when fleeing
    public float fleeDistance = 30f; // Distance at which the object starts fleeing
    public float fleeingSpeed; 

    //not fleeing
    [Header("For not fleeing")]
    public float roamRadius = 10f;
    public float roamTimer = 1000f; //every how many seconds change positions
    private float timer; //temporary variable
    private Vector3 randomDestination;

    public GameEvent fleeModeEvent;
    private DuckSound DuckSoundLocal;

    private void Start()
    {
        isFlee = false;
        isSuspicous = false;
        agent = GetComponent<NavMeshAgent>();
        timer = roamTimer;
        if(gameObject.CompareTag("EnemyRun")) SetRandomDestination();
        DuckSoundLocal = GetComponent<DuckSound>();

    }

    private void Update()
    {
        
        if (isSuspicous || isFlee) //if suspicious or fleeing, run away
        {
            float distance = Vector3.Distance(gameObject.transform.position, player.position);


            if (distance < fleeDistance)
            {
                // Calculate the direction away from the player
                Vector3 fleeDirection = transform.position - player.position;

                // Normalize the flee direction
                fleeDirection.Normalize();

                // Calculate the destination position to flee to
                Vector3 fleePosition = gameObject.transform.position + fleeDirection * fleeDistance;

                // Set the destination for the NavMeshAgent to flee to
                agent.SetDestination(fleePosition);
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f && gameObject.CompareTag("EnemyRun") && !isFlee) //find new position if not fleeing
            {
                SetRandomDestination();
                timer = roamTimer;

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
            if ((collider.CompareTag("Player")) && !GameManager.Instance.isHidden ) // as well as the object not being hidden 
            {
                Debug.Log("reached fleeing mode;");
                fleeMode();
            }
        }
    }

    public void fleeMode()
    {
        isFlee = true;
        Renderer renderer = gameObject.GetComponent<Renderer>(); //change color to red
        renderer.material = fleeMaterial; //change the color of the duck
        DuckSoundLocal.FleeSound();
        agent.speed = fleeingSpeed;
        fleeModeEvent.Raise();
       
    }

    public void SusMode()
    {
        isSuspicous = true;
        agent.speed = suspiciousSpeed;
        if (!isFlee)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>(); //change color to red
            renderer.material = suspiciousMaterial; //change the color of the duck
            DuckSoundLocal.SusSound();
        }
        
       
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
