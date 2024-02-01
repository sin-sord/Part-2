using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Landing : MonoBehaviour
{
    public Collider2D runwayDetection;
    public int planeScore = 0;
    
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        runwayDetection = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)   //this is to have the plane shirnk in size when touching the runway
    {
        //Collider2D hit = Physics2D.OverlapPoint(collision.transform.position);  //verifies the collision overlaping

        if (runwayDetection.OverlapPoint(collision.gameObject.transform.position))
        {
            if (collision.gameObject.GetComponent<Plane>().landingPlane == false)  //referances the Plane object and sets it to false
            {
                collision.gameObject.GetComponent<Plane>().landingPlane = true;  //if the Plane collides
               planeScore++;
            } 
        }
    }

}
