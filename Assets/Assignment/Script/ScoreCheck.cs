using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ScoreCheck : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

    void Score(Collider2D collision) 
    {
        scoreText.text = "Score: " + score;
       
        if (collision.gameObject.tag == "coin")  // if collision happens with the tag "coin" destroy that object and add 1 point to the score
        {
            Destroy(collision.gameObject);  // destroy the coin
            score++;  // a 1 point to the score
        }
    }
}
