using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandom : MonoBehaviour
{
    public GameObject planePrefab;
    public Sprite[] prefabSprite;
    Vector3 spawnPosition;
    public float timeSpawn = 0;
    //SpriteRenderer planeSprite;

    // Start is called before the first frame update
    void Start()
    {

        planePrefab.GetComponent<SpriteRenderer>().sprite = prefabSprite[Random.Range(0, 5)];
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawn += 1 * Time.deltaTime;

        if (timeSpawn > 5) 
        {
            timeSpawn = 0;
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);

            prefabSprite = new Sprite[Random.Range(0, 5)];
            Instantiate(planePrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
                     
        }

    }
}
