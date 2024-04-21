using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class PoliceDuck : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
    bool isFollowing = false;

    // Start is called before the first frame update
    private void Start()
    {
        //gameObject.SetActive(false); //at the start we deactivate the duck
        
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false; 
    }

    //this is where the duck will be following the player, it will do so using navmesh
    public void FollowDuck()
    {
        Debug.Log("hey police active");
        isFollowing = true;
        //gameObject.SetActive(true);
        agent.enabled = true;
    }

    private void Update()
    {
        if (isFollowing)
        {
            agent.SetDestination(player.position);
        }
    }
}
