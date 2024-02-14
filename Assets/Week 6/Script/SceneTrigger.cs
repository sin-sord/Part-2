using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneTrigger : MonoBehaviour
{

    public TextMeshProUGUI sceneName;
    public float speed = 2f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        sceneName = GetComponent<TextMeshProUGUI>();  // get the text element
  //      sceneName.text = SceneManager.GetActiveScene().name; // name of the scene
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
     private void FixedUpdate()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rb.MovePosition(rb.position + direction);
        
    }
}
