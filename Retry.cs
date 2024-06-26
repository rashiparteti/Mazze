using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void RetryLevel()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }
    public void LoadNextLevel()
    {
        // Load the next level named "Main1"
        SceneManager.LoadScene("Main1");
    }

    private void Update()
    {
        RetryLevel();
        LoadNextLevel();
    }

   
}
