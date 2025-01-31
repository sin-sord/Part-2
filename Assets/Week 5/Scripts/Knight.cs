using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


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
        health = PlayerPrefs.GetFloat("HealthStat", maxHealth);
   //   health = maxHealth;
        StatusUpdate();

        SendMessage("HealthSave", health, SendMessageOptions.DontRequireReceiver);
    }


    private void FixedUpdate()
    {
        if (isDead) return;  //  return means stop doing this function, if is dead = true then stop moving
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;  // if the knight reaches where the mouse was pressed then stop moving
           
        }
        RB.MovePosition(RB.position + movement.normalized * speed * Time.deltaTime);  //  moves the knight: knights position + movement * speed
        // movement.normalized: a normalized version of a Vector * Time.deltaTime allows the normalized to increase by set speed
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead) return;  //  return means stop doing this function, if is dead = true then stop moving
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())  // if the left-click on mouse is pressed and is not clicking on itself & if the UI is pressed the knight won't go to where the mouse pressed
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // move the knight to the location of where the mouse was pressed
            
        }
        animator.SetFloat("Movement", movement.magnitude);  // this allows animation to happen when the knight is moving using the float in animator

        if (Input.GetMouseButtonDown(1))  // if right-click on mouse play "attack" animation
        {
            animator.SetTrigger("Attack");
        }


    }

    private void OnMouseDown()
    {
        if (isDead) return;  //  return means stop doing this function, if is dead = true then stop moving
        clickingOnSelf = true;
        animator.SetTrigger("TakeDamage");
        SendMessage("TakeDamage", 1);

    }


    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

     public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        StatusUpdate();
        PlayerPrefs.SetFloat("HealthStat", health);

    }

    public void StatusUpdate()
    {
        if (health <= 0)
        {
            
            animator.SetTrigger("Death");
            isDead = true;
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");  // calls on the trigger set in perameter of animator window, when the mouse is down the animation plays
        }
    }

}
