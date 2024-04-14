using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, Interactable
{
    public Collectible collectibleData;

    public IEnumerator Interact()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.AddToInventory(collectibleData.collectibleID);
        }
        Debug.Log("Collected: " + collectibleData.collectibleID);
        yield return null;
        Destroy(gameObject); // Optionally destroy the object after collection
    }
}
