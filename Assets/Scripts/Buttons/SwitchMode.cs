using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchMode : MonoBehaviour {

    // Change between Size and Distance modes
    public void switchMode()
    {
        // Get the current scene index
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        // Switch between scenes 1 and 2
        if (currentScene == 0 || currentScene == 2)
        {
            currentScene = 1;
            GameController.currentMode = "ScaleMode";
        }
        else if (currentScene == 1)
        {
            currentScene = 2;
            GameController.currentMode = "DistanceMode";
        }

        // Set currentMode to the new mode

        // Load the new scene
        SceneManager.LoadScene(currentScene);
    }

}
