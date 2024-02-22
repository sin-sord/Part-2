using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge;
    Vector2 direction;
    public TextMeshProUGUI scoreUpdate;
    public static float scoreSet = 0;

    public static BallMan CurrentSelection { get; private set; }
    public static Ball ScoreTrack { get; private set; }

    public static void SetCurrentSelection(BallMan player)
    {
        if(CurrentSelection != null)  // if the CurrentSelection is nothing, revert to OG color
        {
            CurrentSelection.Selected(false);
        }
        CurrentSelection = player;  //  CurrentSelection is the player
        CurrentSelection.Selected(true);  // change color if true
    }

    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            CurrentSelection.Move(direction);
            direction = Vector2.zero;  // stops the player
        }
    }


    private void Update()
    {
        scoreUpdate.text = "Score: " + scoreSet.ToString();  // if the player shoots the ball and scores they get a point

        if (CurrentSelection == null) return;

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            charge = 0;
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;  // charge increases
            charge = Mathf.Clamp(charge, 0, maxCharge);  // setting charges min and max value
            chargeSlider.value = charge;  // slider value is equal to charge
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)CurrentSelection.transform.position).normalized * charge;  // moving the player the mouse where the mouse it, CurrentSelection = player (in this case Ballman)
        }
    }
}
