using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMan : MonoBehaviour
{
    //public bool selected = false;
    public SpriteRenderer changecolor;
    Rigidbody2D rb;
    public float speed = 100;
    public Color picked;
    public Color unpicked;


    void Start()
    {
        changecolor = GetComponent<SpriteRenderer>();  // allows for color change
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }


    private void OnMouseDown()
    {
        Selected(true);
        Controller.SetCurrentSelection(this);
    }



    public void Selected(bool selected)
    {
        if (selected == true)  // if the player is selected on MouseDown
        {
            changecolor.color = picked;  // change the color to blue
        }
        else   // if the player is deselected on MouseUp
        {
            changecolor.color = unpicked;  // return to OG color. return; is saying to end the function
        }      
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);  // move the rigidbody by direction * speed, by its mass
    }
}




