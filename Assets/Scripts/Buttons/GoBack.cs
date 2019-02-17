using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    void Awake()
    {
        //Initialize button
        GameController.buttonBack = gameObject;
        gameObject.SetActive(false);
    }

    public void goBack()
    {
        // Get the chosen planet object
        GameObject chosenPlanet = GameObject.Find(GameController.chosenPlanet);

        // If Size Mode do reset to Scale Mode
        chosenPlanet.GetComponent<PlanetController>().ResetPlanet();

        // If Distance Mode do reset to Distance Mode


        // Disable the "Go Back" button
        gameObject.SetActive(false);

        // Enable the "Switch" button
        GameController.buttonSwitch.SetActive(true);


    }
}
