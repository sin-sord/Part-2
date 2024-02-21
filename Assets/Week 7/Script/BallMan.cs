using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMan : MonoBehaviour
{
    public bool selected = false;
    public SpriteRenderer changecolor;

    void Start()
    {
        changecolor = GetComponent<SpriteRenderer>();  // allows for color change
    }


    void Update()
    {
        Selected();  // the function runs everyframe rather than happening one time like a flash.
    }


    private void OnMouseDown()
    {
        selected = true;  // on MouseDown, selected = true
    }
    private void OnMouseUp()
    {
        selected = false;  // on MouseUp, selected = false
    }


    public void Selected()
    {
        if (selected == true)  // if the player is selected on MouseDown
        {
            changecolor.color = Color.blue;  // change the color to blue
        }
        else if (selected == false)  // if the player is deselected on MouseUp
        {
            return;  // return to OG color. return; is saying to end the function
        }      
    }
}




