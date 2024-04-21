using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMiniCamera : MonoBehaviour
{
    public GameObject Player;
    public float offset; 

    private void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + offset, Player.transform.position.z);
       
    }
}
