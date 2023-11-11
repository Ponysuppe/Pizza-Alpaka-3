using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        if (stopSpawning)
            CancelInvoke("SpawnEnemy");
    }
}
