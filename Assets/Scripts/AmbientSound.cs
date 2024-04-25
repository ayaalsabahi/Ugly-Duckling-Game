using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public AudioClip sound;


    private AudioSource soundSource;
    public Transform player;
    public float minVolumeDistance;
    public float maxVolumeDistance;
    public float maxVolume = 1.0f;

    private void Awake()
    {
        soundSource = gameObject.AddComponent<AudioSource>();
        soundSource.clip = sound;
        soundSource.minDistance = minVolumeDistance;
        soundSource.maxDistance = maxVolumeDistance;
        soundSource.loop = true;
        soundSource.Play();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);
        //Debug.Log("dist to player" + distanceToPlayer);
        float normalizedDistance = Mathf.Clamp01((distanceToPlayer - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
        float volume = Mathf.Clamp01(1.0f - Mathf.Log(normalizedDistance + 1.0f) / Mathf.Log(2.0f));
        soundSource.volume = volume * maxVolume;
    }


}