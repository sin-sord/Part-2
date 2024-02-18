using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMove : MonoBehaviour
{
    public Rigidbody2D rb;
    
    Vector2 movePlayer;  // for the movement of the player
    Vector2 guidePlayer;   // for the direction
    public float speed = 4f;  //speed of player
    
    Animator Anim;  // allows for animating the player
    
    public float playerHealth;  //health system of player
    public float PlayerHealthMax = 3;  //max health of player

    bool death = false;

    private int score = 0;
    public Text scoreText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        playerHealth = PlayerHealthMax;

    }

     void Update()
    {
        scoreText.text = "Score: " + score;

        if (death) return;  // if death occurs then stop this function
        if (Input.GetMouseButtonDown(0))   // if the left mouse button is pressed then have the player move to where the mouse clicked.
        {
            guidePlayer = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // the guide is where the mouse is pressed on the screen

        }

        Anim.SetFloat("Movement", movePlayer.magnitude);  // plays the movement animation clip
    }

    private void FixedUpdate()   // Movement for the player
    {
        if (death) return;  // if death occurs then stop this function
        movePlayer = guidePlayer - (Vector2)transform.position;
        if (movePlayer.magnitude < 0.1)  // if the players magnitude is less that 0.1 then stop moving
        {
            movePlayer = Vector2.zero;
        }

        rb.MovePosition(rb.position + movePlayer.normalized * speed * Time.deltaTime);  // moves the rigidbody to where the mouse pressed.

        float rotate = Mathf.Atan2(movePlayer.y, movePlayer.x) * Mathf.Rad2Deg;  // allows for the robot to rotate and move to the direction where the mouse was pressed.
        transform.rotation = Quaternion.Euler(0,0,rotate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "thorn" && !death) // if the player touches a thron and is not dead they continue the hurt animation
        {
            SendMessage("HurtPlayer", 1);  // sends a message that when the player collides with a spike then take damage
            Anim.SetTrigger("Hurt");
        }

        if (collision.gameObject.tag == "coin") 
        {
            scoreCoin(collision);  // if the player collides with a coin then add 1 score point
            Debug.Log("collected");
        }

    }

    public void HurtPlayer(float thorn)  //if the player touches a thorn then they get hurt
    {

            playerHealth -= thorn;
            playerHealth = Mathf.Clamp(playerHealth, 0, PlayerHealthMax);
            if (playerHealth <= 0 && !death)  // if the players health is 0 and is not dead, then the bool Death is true and it plays the dead animation
            {
            death = true;
            Anim.SetTrigger("Dead");
            // if the player is killed then go to the next scene, Game Over
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);  // loads the next scene
        }
    }

    public void scoreCoin(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            score++;
            if (score == 5)
            {
                // if the player collects all coins then go to the next scene, Game Over
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
                    SceneManager.LoadScene(nextSceneIndex);  // loads the next scene
                
            }
        }
    }

}


