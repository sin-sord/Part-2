using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{
    TextMeshProUGUI sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneName = GetComponent<TextMeshProUGUI>();  // get the text element
        sceneName.text = SceneManager.GetActiveScene().name; // name of the scene

    }





    // Update is called once per frame
    void Update()
    {


        
    }
}
