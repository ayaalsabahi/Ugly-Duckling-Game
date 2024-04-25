using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSound : MonoBehaviour
{
    AudioSource sound;

    void Start()
    {
        // Assuming your looping sound GameObject is named "SoundManager"
        sound = GameObject.Find("SoundManager").GetComponent<AudioSource>();

        // Check if the AudioSource component is not null and then play the sound
        if (sound != null)
        {
            sound.Play();
           
        }
    }
}
