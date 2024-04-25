using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; 

public class PoliceDuck : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
    bool isFollowing = false;
    public float followSpeed = 50f;

    private PoliceSound localSound; 

    [Header("For not fleeing")]
    public float roamRadius = 10f;
    public float roamTimer; //every how many seconds change positions
    private float timer; //temporary variable
    private Vector3 randomDestination;
    public float normalSpeed;




    // Start is called before the first frame update
    private void Start()
    {
        //gameObject.SetActive(false); //at the start we deactivate the duck
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed;
        localSound = GetComponent<PoliceSound>();
    }

    //this is where the duck will be following the player, it will do so using navmesh
    public void FollowDuck()
    {
        isFollowing = true;
        agent.enabled = true;
        agent.speed = followSpeed;
        localSound.playPolice();
    }

    private void Update()
    {
        if (isFollowing && !GameManager.Instance.isHidden) //only follow if not hiding
        {
            agent.SetDestination(player.position);
            GameManager.Instance.isFleeing = true; 
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f) //find new position if not fleeing
            {
                SetRandomDestination();
                timer = roamTimer;

            }
        }
        
    }

    public void DontFollowDuck()
    {
        isFollowing = false; //basically stop where you are / roam around -> something to change later on
        GameManager.Instance.isFleeing = false;
        localSound.policeStop(); //stop the ringing that is going on 
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

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the player
        if (collision.gameObject.CompareTag("Player") && isFollowing)
        {
            SceneManager.LoadScene("GameOver");
            // Here you can add any actions you want to take when the object collides with the player
        }
    }
}
