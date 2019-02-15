using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    void Awake()
    {
        //Initialize button
        GameController.button = gameObject;//.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void goBack()
    {
        //string currentMode = GameController.currentMode;
        // Get the chosen planet object
        GameObject chosenPlanet = GameObject.Find(GameController.chosenPlanet);
        
        
        // Reset the planets back to the current mode's settings

        // If Size Mode do reset to Scale Mode
        //if (currentMode == "ScaleMode")
            chosenPlanet.GetComponent<PlanetController>().ResetPlanet();

        // If Distance Mode do reset to distance mode
        //else if (currentMode == "DistanceMode")



        // Deactivate the button
        gameObject.SetActive(false);
    }
}
