using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeEditor;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GoalKeeperController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public GameObject goalie;
    public float goalieDistance = 4;
    public float goalieSpeed = 4;
    Vector3 playerPos;


    void Start()
    {
        rb = goalie.GetComponent<Rigidbody2D>();
    }


    void Update()
     {
         playerPos = Controller.CurrentSelection.transform.position;
        direction = (playerPos - transform.position).normalized;  // setting up direction

         if (Vector3.Distance(playerPos, transform.position) < goalieDistance * 2) // if the selected player is less than the goalies max distance * 2...
         {
             goalie.transform.position = Vector3.MoveTowards(goalie.transform.position, (transform.position + (Vector3)(Vector3.Distance(playerPos, transform.position) / 2 * direction)), goalieSpeed * Time.deltaTime);  // have the goalies max distance decrease at the player gets closer.
         }
         else
         {
             goalie.transform.position = Vector3.MoveTowards(goalie.transform.position, (transform.position + (Vector3)(goalieDistance * direction)), goalieSpeed * Time.deltaTime); // else, have the goalie move within the max set distance
         }
     }
 }
    
