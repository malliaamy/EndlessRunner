using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Transform spawner;
    public GameObject groundObstacle;
    public GameObject airObstacle;
    public GameObject coin;
    GameObject rand; 
    int height;
    float randInterval;
    // Start is called before the first frame update
    void Start()
    {
        randInterval = Random.Range(0.5f, 4f);
        Invoke("SpawnObstacle", randInterval);
        Invoke("CoinSpawn", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        int randObstacle = Random.Range(1, 3);
        if(randObstacle == 1)
        {
            rand = groundObstacle;
            height = 12;
        }
        else
        {
            rand = airObstacle;
            height = 14;
        }
        
    }

    void SpawnObstacle()
    {
        randInterval = Random.Range(2f, 3f);
        Instantiate(rand, new Vector2(spawner.position.x, height), Quaternion.identity);

        Invoke("SpawnObstacle", randInterval);
    }

    void CoinSpawn()
    {
        int randCoinInt = Random.Range(1, 10);
        if (randCoinInt == 1)
        {
            Instantiate(coin, new Vector2(spawner.position.x, 13), Quaternion.identity);
        }

        Invoke("CoinSpawn", 1f);
    }

}
