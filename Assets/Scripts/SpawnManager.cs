using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    private float spawnDelay = 2f;
    private float spawnInterval = 2f;
    private List<GameObject> spawnedSideAnimals = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalTop", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalSide", spawnDelay, spawnInterval+1);
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    void SpawnRandomAnimalTop()
    {
        //Generate random index to choose which animal to spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Generate random position for the animal to spawn in
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    
    void SpawnRandomAnimalSide()
    {
        //Generate random index to choose which animal to spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Generate random position for the animal to spawn in
        Vector3 spawnPosRight = new Vector3(spawnRangeX+6, 0, Random.Range(-spawnRangeZ+20,spawnRangeZ-8));
        Vector3 spawnPosLeft = new Vector3(-spawnRangeX-6, 0, Random.Range(-spawnRangeZ+20, spawnRangeZ-8));

     
        Instantiate(animalPrefabs[animalIndex], spawnPosRight,  Quaternion.Euler(0,-90,0));
        Instantiate(animalPrefabs[animalIndex], spawnPosLeft,  Quaternion.Euler(0, 90, 0));
    }
}
