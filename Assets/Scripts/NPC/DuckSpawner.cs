using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab; // Assign this in the inspector with your pizza prefab
    public float spawnInterval = 1.0f; // Time between each spawn
    public float ducksToSpawn;
    public bool isOn;

    void Start()
    {
        ducksToSpawn = 10;
        isOn = false;
    }

    // Start is called before the first frame update
    void Update()
    {
        
        if(ducksToSpawn > 0 & isOn)
        {
            StartCoroutine(SpawnDuckRoutine());
            ducksToSpawn--;
            Debug.Log("start");
        }
    }

    public void TurnOn()
    {
        isOn = true;
    }

    private IEnumerator SpawnDuckRoutine()
    {
        while (ducksToSpawn > 0 & isOn) // Infinite loop to keep spawning pizzas
        {
            yield return new WaitForSeconds(spawnInterval); // Wait for specified interval
            SpawnDuck();
            Debug.Log("one less");
        }
    }

    private void SpawnDuck()
    {
        
        GameObject newObject = Instantiate(duckPrefab, transform.position, Quaternion.identity) as GameObject; // Spawn the pizza at the position of the GameObject this script is attached to
        newObject.transform.localScale = new Vector3(5, 5, 5);
        Debug.Log("spawning");
    }
}
