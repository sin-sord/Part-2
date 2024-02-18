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
        /*
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    score++;
                }*/
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            score++;
        }
    }
}
