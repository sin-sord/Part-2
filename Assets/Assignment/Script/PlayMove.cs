using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        playerHealth = PlayerHealthMax;

    }

     void Update()
    {
        if (death) return;
        if (Input.GetMouseButtonDown(0))   // if the left mouse button is pressed then have the player move to where the mouse clicked.
        {
            guidePlayer = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("Robot move");
        }

        Anim.SetFloat("Movement", movePlayer.magnitude);  // plays the movement animation clip
    }

    private void FixedUpdate()   // Movement for the player
    {
        if (death) return;
        movePlayer = guidePlayer - (Vector2)transform.position;
        if (movePlayer.magnitude < 0.1)  // if the players magnitude is less that 0.1 then stop moving
        {
            movePlayer = Vector2.zero;
            Debug.Log("Robot stop");
        }

        rb.MovePosition(rb.position + movePlayer.normalized * speed * Time.deltaTime);

        float rotate = Mathf.Atan2(movePlayer.y, movePlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotate, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "thorn" && !death) // if the player touches a thron and is not dead they continue the hurt animation
        {
            SendMessage("HurtPlayer", 1);
            Anim.SetTrigger("Hurt");
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
            }
    }

}


