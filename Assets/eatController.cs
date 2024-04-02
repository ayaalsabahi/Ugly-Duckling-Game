using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatController : MonoBehaviour
{
    private ParticleSystem particleSystemEnemy;

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
    }

    public void Deactivate()
    {
        Debug.Log("Particle system deactivated");
        particleSystemEnemy.Stop();
    }
}
