using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void taskOnClick()
    {
        // Get the chosen planet object
        GameObject chosenPlanet = GameObject.Find(PlanetsInit.chosenPlanet);

        // Get the RectTransform from chosen planet object
        RectTransform planetRectTransform = chosenPlanet.GetComponent<RectTransform>();
        PlanetController planetScript = chosenPlanet.GetComponent<PlanetController>();

        // Set this planet to the global "size" position
        planetRectTransform.anchoredPosition = new Vector2(planetScript.sizeModeX, planetScript.sizeModeY);

        // Deactivate all the text objects belonging to this planet
        chosenPlanet.transform.Find("Description").gameObject.SetActive(false);
        chosenPlanet.transform.Find("Diameter").gameObject.SetActive(false);
        chosenPlanet.transform.Find("Temperature").gameObject.SetActive(false);
        chosenPlanet.transform.Find("Gravity").gameObject.SetActive(false);
        chosenPlanet.transform.Find("NumMoons").gameObject.SetActive(false);

        // Set chosen planet back to none
        PlanetsInit.chosenPlanet = "none";

        // Deactivate the button
        gameObject.SetActive(false);
    }
}
