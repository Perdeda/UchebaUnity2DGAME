using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private float randx,y = -1.32f;
    Vector2 WhereToSpawn;
    public float spawnRate = 2.0f;
    float nextSpawn = 0.0f;
    int amount = 0;
    public int MaxAmount = 15;
    private float initSpawnrate;

    void Start()
    {
         initSpawnrate = spawnRate;
    }

   
    void Update()
    {
        if(Time.time > nextSpawn && MaxAmount >= amount)
        {
            amount++;
            nextSpawn = Time.time + spawnRate;
            randx = Random.Range(2.1f, 2.4f);
            WhereToSpawn = new Vector2(randx, y);
            Instantiate(enemy, WhereToSpawn, Quaternion.identity);
        }
        //SPAWN SPRAVA + UDVOYENIYE
        //if (Time.time > nextSpawn && MaxAmount >= amount/2)
        //{
        //    amount++;
        //    nextSpawn = Time.time + spawnRate;
        //    randx = Random.Range(-2.6f, -1.6f);
        //    WhereToSpawn = new Vector2(randx, y);
        //    Instantiate(enemy, WhereToSpawn, Quaternion.identity);
        //    if (spawnRate == initSpawnrate)
        //    {
        //        spawnRate = spawnRate / 2;
        //    }
        //}
        if (MaxAmount <= amount)
        {
            FindObjectOfType<GameManager>().End();
        }
    }
}
