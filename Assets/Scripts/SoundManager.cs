using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip smallBiteSound;
    public AudioClip bigBiteSound;


    private AudioSource smallBiteSource;
    private AudioSource bigBiteSource; 

    //singleton setup 
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //in case we add more scenes later on things should not change
        }
    }

    public void Start()
    {
        smallBiteSource = gameObject.AddComponent<AudioSource>();
        bigBiteSource = gameObject.AddComponent<AudioSource>();

        smallBiteSource.clip = smallBiteSound;
        bigBiteSource.clip = bigBiteSound; 
    }


    public void smallBitePlay()
    {
        smallBiteSource.Play();
    }

    public void bigBitePlay()
    {
        bigBiteSource.Play();
    }
}
