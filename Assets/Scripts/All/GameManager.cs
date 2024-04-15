using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    //making it a singleton, refrence: https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    public static GameManager Instance { get; private set; }



    //create a timer for how long they have that functionality later on??
    public GameObject greenery1; //we can make an array of different greenieries to be unlocked later on
    public Material newMaterial;
    public GameObject mainDuck; 
    public Vector3 newScale = new Vector3(2f, 2f, 2f); // New scale for the object



    public bool isHidden = false; //refers to whether we are in the weeds or not 
    public float detectionRadius; 
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        DialogueManager.Instance.OnShowDialogue += () =>
        {
            //state = GameState.Dialogue;
        };

        DialogueManager.Instance.OnCloseDialogue += () =>
        {
            //if (GameState.Dialogue)
            //state = GameState.FreeRoam;
        };

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


        Collider collider = greenery1.GetComponent<Collider>();
        collider.isTrigger = true; //change the ability to pass through greenery

        Transform transform = mainDuck.transform;
        transform.localScale = newScale; //change the object scale 

    }



}
