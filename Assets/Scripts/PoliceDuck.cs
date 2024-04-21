using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class PoliceDuck : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent currentAgent;
    bool isFollowing = false;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false); //at the start we deactivate the duck
        currentAgent = GetComponent<NavMeshAgent>();
    }

    //this is where the duck will be following the player, it will do so using navmesh
    public void FollowDuck()
    {
        isFollowing = true;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isFollowing)
        {
            currentAgent.SetDestination(player.position);
        }
    }
}
