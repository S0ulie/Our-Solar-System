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
        // Flip between 0 and 1 to get the other scene
        currentScene ^= 1;
        // Load the new scene
        SceneManager.LoadScene(currentScene);

        // Set currentMode to the new mode
        //GameController gameScript = GameObject.Find("SolarSystemInit").GetComponent<GameController>();
        GameController.currentMode = SceneManager.GetActiveScene().name;
    }

}
