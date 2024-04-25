using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonSound : MonoBehaviour
{
    public AudioClip soundClip; // Drag and drop your sound clip into this field in the Unity editor
    private AudioSource audioSource;

    private float timer = 0f;
    public float interval = 3f; // Interval in seconds between each sound

    public Transform player;
    public float minVolumeDistance;
    public float maxVolumeDistance;
    public float maxVolume = 1.0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there's no AudioSource component attached to this GameObject, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            // Play the sound
            if (soundClip != null)
            {
                audioSource.PlayOneShot(soundClip);
            }

            // Reset the timer
            timer = 0f;
        }

        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);
        float normalizedDistance = Mathf.Clamp01((distanceToPlayer - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
        float volume = Mathf.Clamp01(1.0f - Mathf.Log(normalizedDistance + 1.0f) / Mathf.Log(2.0f));
        audioSource.volume = volume * maxVolume;
    }
}
