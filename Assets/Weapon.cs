using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float speed = 3;
    public GameObject spear;
    public Rigidbody2D rb;
    public float timer = 0;
    public float timeMax = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    //    spear = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rb.MovePosition(rb.position + direction);

        timer += 1 * Time.deltaTime;
        if (timer > timeMax)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
        Debug.Log("spear hit");
       
    }

   
}
