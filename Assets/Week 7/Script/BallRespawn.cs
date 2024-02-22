using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Transform respawn;
    public GameObject reBall;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(reBall, respawn.position, respawn.rotation);

    }
}
