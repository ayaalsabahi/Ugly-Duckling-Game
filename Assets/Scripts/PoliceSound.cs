using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSound : MonoBehaviour
{
    public AudioClip policeSound;
    private AudioSource policeSource;
    public Transform player;
    public float minVolumeDistance;
    public float maxVolumeDistance;
    public float maxVolume = 1.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        policeSource = gameObject.AddComponent<AudioSource>();
        policeSource.clip = policeSound;
        policeSource.minDistance = minVolumeDistance;
        policeSource.maxDistance = maxVolumeDistance;
        policeSource.loop = true;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);
        float normalizedDistance = Mathf.Clamp01((distanceToPlayer - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
        float volume = Mathf.Clamp01(1.0f - Mathf.Log(normalizedDistance + 1.0f) / Mathf.Log(2.0f));
        policeSource.volume = volume * maxVolume;
    }


    public void playPolice()
    {
        policeSource.Play();
    }

    public void policeStop()
    {
        policeSource.Stop();
    }
}
