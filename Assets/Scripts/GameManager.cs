using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //create a timer for how long they have that functionality later on??

    //change the skin to be bigger & different color

    public GameObject greenery;
    public Material newMaterial;
    public GameObject mainDuck; 
    public Vector3 newScale = new Vector3(2f, 2f, 2f); // New scale for the object

    private void Start()
    {
       
    }

    public void BiggerAbility()
    {
        //change skin
        //set the greenery to isTrigger and be able to pass through it

        // Get the Renderer component attached to this GameObject
        Renderer renderer = mainDuck.GetComponent<Renderer>();
        renderer.material = newMaterial; //change the color of the duck


        Collider collider = greenery.GetComponent<Collider>();
        collider.isTrigger = true; //change the ability to pass through greenery

        Transform transform = mainDuck.transform;

        transform.localScale = newScale; //change the object size 

    }


    //this checks if there are any enemies near us after if being eaten
    
    public void DuckEaten()
    {
        //if hiding in the grass we're safe


        //otherwise, set things off to high alert
    }
}
