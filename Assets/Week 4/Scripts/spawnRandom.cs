using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandom : MonoBehaviour
{
    public GameObject planePrefab;
    
    Vector3 spawnPosition;
    public float timeSpawn = Random.Range(1, 5);
    public float randomTime = Random.Range(1, 5);
    public float spawnZ = Random.Range(1, 5);
    //SpriteRenderer planeSprite;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(1, 5);
        timeSpawn = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawn += 1 * Time.deltaTime;

        if (timeSpawn > randomTime) 
        {
            timeSpawn = 0;
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);

            
            Instantiate(planePrefab, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            
        }

    }
}
