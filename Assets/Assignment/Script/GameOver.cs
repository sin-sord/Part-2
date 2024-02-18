using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //once the player reaches the end of the game and the Game Over scene comes, the player can either replay the game or quit to the title scene
    public void quitOption() // go back to the title scene
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex -2 ) % SceneManager.sceneCountInBuildSettings;  
        SceneManager.LoadScene(nextSceneIndex);  // loads the next scene
    }

    public void retryOption() // go back to the game scene
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);  // loads the next scene
    }

}
