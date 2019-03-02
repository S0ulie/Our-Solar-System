using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // Get the current mode
    public string currentMode = GameController.currentMode;
    public static GameObject distanceObj;

    private void Awake()
    {
        // If distance mode, then get a reference to the distance planet
        if (currentMode == "DistanceMode")
            distanceObj = GameObject.Find("Distance Planet");

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
