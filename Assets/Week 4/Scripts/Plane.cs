using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{

    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigidbody = GetComponent<Rigidbody2D>();

     
    }

    void FixedUpdate()  //rotate and move plane to point

    {
        currentPosition = transform.position;  
        if(points.Count > 0)  //rotation code if there is a path to follow
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;   // - numbers rotate clockwise
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);   //this will move the plane to move
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.4f * Time.deltaTime;  //interpolation
            float interpolation = landing.Evaluate(landingTimer);  //making timer bigger every frame, if x value increases it finds the y value.
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);  // this will decrease the size of the plane when it lands
        }
        lineRenderer.SetPosition(0, transform.position);   // make sure current point is moving
        if(points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)  // this will delete the path following behind the plane
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));   //shifting the whole of the array and stuffing it in the last point
                }
                if(lineRenderer.positionCount != 0)
                lineRenderer.positionCount--;
            }
        }
    }


    void OnMouseDown()
    {

        points = new List<Vector2>();   //this will make the line be drawn when the mouse is pressed down
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }


    void OnMouseDrag()  //draws a line
    {

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold )
        {
        points.Add(newPosition);
        lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount -1, newPosition);
        lastPosition = newPosition;
        }

    }
   
}
