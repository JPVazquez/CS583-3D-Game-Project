using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    int previousSceneIndex;

    void Start()
    {
        // Lock the cursor (optional)
        Cursor.lockState = CursorLockMode.None;

        // Show the cursor
        Cursor.visible = true;

        // Get the previous scene index from PlayerPrefs
        previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex");
    }

    //Load previous scene from button
    public void RestartPreviousScene()
    {
        //Check if previous scene index is valid, is so, load previous scene
        if (previousSceneIndex >= 0 && previousSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("Invalid previous scene index!");
        }
    }

    //Load main menu scene from button
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
