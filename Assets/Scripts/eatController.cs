using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatController : MonoBehaviour
{
    private ParticleSystem particleSystemEnemy;
    private int eatCount = 0; //this tells us how many times space was pressed
    public int maxEat = 5; //number of times to press before an object gets eaten

    [Header("Events")]
    public GameEvent biggerAbility;
    public GameEvent duckEaten; 

    private void Start()
    {
        particleSystemEnemy = GetComponent<ParticleSystem>();

        if (particleSystemEnemy == null)
        {
            // If the ParticleSystem component is not found, log an error
            Debug.Log("No ParticleSystem component found on this GameObject!");
        }

        else
        {
            particleSystemEnemy.Stop();
        }

    }

    public void Activate()
    {
        Debug.Log("particle system activated");
        particleSystemEnemy.Play();
        eatCount++;
        if(eatCount == maxEat)
        {
            duckEaten.Raise();
            Destroy(gameObject);

            if(gameObject.CompareTag("biggerDuck")) //different ducks give different abilities
                                                //pass it onto the level manager to say
                                                //that you got a certain ability & the level manager handles it
            {
                biggerAbility.Raise();
                
            }
        }
    }

    public void Deactivate()
    {
        Debug.Log("Particle system deactivated");
        particleSystemEnemy.Stop();
    }
}