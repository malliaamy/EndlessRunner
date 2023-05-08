using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Transform spawner;
    public GameObject groundObstacle;
    public GameObject airObstacle;
    GameObject rand; 
    int height;
    float randInterval;
    // Start is called before the first frame update
    void Start()
    {
        randInterval = Random.Range(0.5f, 2.0f);
        InvokeRepeating ("SpawnObstacle", randInterval, randInterval);
    }

    // Update is called once per frame
    void Update()
    {
        int randObstacle = Random.Range(1, 3);
        randInterval = Random.Range(5f, 10f);
        if(randObstacle == 1)
        {
            rand = groundObstacle;
            height = 12;
        }
        else
        {
            rand = airObstacle;
            height = 15;
        }

    }

    void SpawnObstacle()
    {
        Instantiate(rand, new Vector2(spawner.position.x, height), Quaternion.identity);
    }

}
