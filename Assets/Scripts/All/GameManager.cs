using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{


    //making it a singleton, refrence: https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    public static GameManager Instance { get; private set; }

    private enum GameState
    {
        FreeRoam,
        Dialogue
    }

    GameState state;

    //create a timer for how long they have that functionality later on??
    //public GameObject greenery1; //we can make an array of different greenieries to be unlocked later on
    //public Material newMaterial;
    public GameObject mainDuck; 
    public Vector3 newScale = new Vector3(2f, 2f, 2f); // New scale for the object

    public bool isHidden; //refers to whether we are in the weeds or not
    public bool isFleeing; //this is if we are running away from the cops
    public float detectionRadius;


    [Header("Timer things")]
    public float timeNeeded;
    private float timeAccumelated; 
    public GameEvent doneHiding;
    public Slider slideBar; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        slideBar.value = 0;
        isHidden = false;
        isFleeing = false; 
    }

    private void Update()
    {
        
        if (isHidden && isFleeing)
        {
            
            timeAccumelated += Time.deltaTime;
            slideBar.value = timeNeeded - timeAccumelated; 
            if(timeAccumelated >= timeNeeded)
            {
                doneHiding.Raise();
                slideBar.value = 0;
                isFleeing = false; 
            }
        }

        if(!isHidden & isFleeing)
        {
            setBar();
        }

       
    }


    public void Hiding() //hidding in the weeds
    {
        isHidden = true;
    }

    public void NotHiding()
    {
        isHidden = false;
    }

    //change the skin to be bigger & different color
    public void BiggerAbility()
    {
        //change skin for later on
        //set the greenery to isTrigger and be able to pass through it

        // Get the Renderer component attached to this GameObject
        //Renderer renderer = mainDuck.GetComponent<Renderer>();
        //renderer.material = newMaterial; //change the color of the duck


        //Collider collider = greenery1.GetComponent<Collider>();
        //collider.isTrigger = true; //change the ability to pass through greenery

        Transform transform = mainDuck.transform;
        transform.localScale = newScale; //change the object scale 

    }

    public void setBar()
    {
        slideBar.value = timeNeeded; 
    }

}
