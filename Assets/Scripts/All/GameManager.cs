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
        Dialogue,
        Rampage
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
    public bool allDucksEaten;


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
        allDucksEaten = false;
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

        if(state == GameState.Rampage && allDucksEaten)
        {
            DisplayRampageEnd();
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

        Transform transform = mainDuck.transform;
        transform.localScale *= 1.1f; //change the object scale 

    }

    public void setBar()
    {
        slideBar.value = timeNeeded;
        timeAccumelated = 0;
    }

    public void DisplayRampageEnd()
    {

    }

    public void CheckIfAllEaten()
    {
        
    }
}
