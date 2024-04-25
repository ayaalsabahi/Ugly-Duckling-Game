using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class eatController : MonoBehaviour
{

    /*
        Attatch this to any enemy that would be eaten, this solely takes care of
        checking what type of object is being eaten as well as raising the corresponding event related to it
        also controlling the particle system & how many ducks need to be eaten
     */ 
    private ParticleSystem particleSystemEnemy;
    public int eatCount = 0; //this tells us how many times space was pressed
    public int maxEat = 5; //number of times to press before an object gets eaten

    [Header("Events")]
    public GameEvent biggerAbility;
    public GameEvent duckEaten;
    public GameEvent smallBite;

    public Collectible item;

    private enemyFlee enemyFleeScriptLocal;
    private DuckSound duckSoundLocal; 
    public Slider duckSlider; 

    private void Start()
    {
        duckSlider.value = maxEat;
        particleSystemEnemy = GetComponent<ParticleSystem>();
        enemyFleeScriptLocal = GetComponent<enemyFlee>();

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
        
        particleSystemEnemy.Play();
        eatCount++;
        smallBite.Raise();
        duckSlider.value -= 1;
        
        if (eatCount == maxEat)
        {
            duckEaten.Raise();
            if(item != null)
            {
                GameObject.Find("PlayerDuck").GetComponent<PlayerController>().AddToInventory(item.collectibleID);
            }
            Destroy(gameObject);
            if (gameObject.CompareTag("biggerDuck") ) //different ducks give different abilities
                                                        //pass it onto the level manager to say
                                                        //that you got a certain ability & the level manager handles it
                {
                biggerAbility.Raise();
                Debug.Log("Reached bigger duck mode");
                }
        }
        if (gameObject.CompareTag("EnemyRun"))
        {
            //now I'm suspicious and want to run away
            enemyFleeScriptLocal.SusMode();
            Debug.Log("Reached sus mode");
           
        }
    }

    public void Deactivate()
    {
        Debug.Log("Particle system deactivated");
        particleSystemEnemy.Stop();
    }
}
