using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knight : MonoBehaviour
{
    Rigidbody2D RB;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Animator animator;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        RB=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        
    }


    private void FixedUpdate()
    {
        if (isDead) return;  //  return means stop doing this function, if is dead = true then stop moving
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;  // if the knight reaches where the mouse was pressed then stop moving
            Debug.Log("Knight stops");
        }
        RB.MovePosition(RB.position + movement.normalized * speed * Time.deltaTime);  //  moves the knight: knights position + movement * speed
        // movement.normalized: a normalized version of a Vector * Time.deltaTime allows the normalized to increase by set speed
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead) return;  //  return means stop doing this function, if is dead = true then stop moving
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf)  // if the left-click on mouse is pressed and is not clicking on itself
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // move the knight to the location of where the mouse was pressed
            Debug.Log("Knight Moves");
        }
        animator.SetFloat("Movement", movement.magnitude);  // this allows animation to happen when the knight is moving using the float in animator
    }

    private void OnMouseDown()
    {
        if (isDead) return;  //  return means stop doing this function, if is dead = true then stop moving
        clickingOnSelf = true;
        TakeDamage(1);   // calls on the trigger set in perameter of animator window, when the mouse is down the animation plays
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
        else 
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");  // calls on the trigger set in perameter of animator window, when the mouse is down the animation plays
        }
    }
}
