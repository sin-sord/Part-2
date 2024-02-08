using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject SpearPrefab;
    public Transform Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void InstantiateSpear()
    {
       
            Debug.Log("spear thrown");
            Instantiate(SpearPrefab, Spawn.position, Spawn.rotation);
        
    }
}
