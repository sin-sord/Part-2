using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    private int score = 0;
    //  public Text scoreText;
    Controller controller;
    public GameObject KickOff;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScoreGoal(false);

    }

    void Update()
    {
    //        scoreText.text = "Score: " + score;
    }

    public void ScoreGoal(bool hit)
    {
        if (hit == true)
        {
            score += 1;

            Debug.Log("player score");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.transform.position = KickOff.transform.position;
        rb.velocity = new Vector2(0, 0);
        Controller.scoreSet = score;
        Controller.scoreSet += 1;  // calling on Controller scoreSet for when the player gets the ball into the net, activiating the trigger, it adds a point

        Debug.Log("Ball reset");
    }

}
