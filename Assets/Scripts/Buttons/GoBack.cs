using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    public void goBack()
    {
        // Get the chosen planet object
        GameObject chosenPlanet = GameObject.Find(PlanetsInit.chosenPlanet);
        // Get the chosen planet's child image transform
        var imageObj = chosenPlanet.transform.Find("Image");
        var nameObj = chosenPlanet.transform.Find("Name");

        // Get the RectTransform from chosen planet object
        RectTransform planetRectTransform = chosenPlanet.GetComponent<RectTransform>();
        RectTransform nameRectTransform = nameObj.GetComponent<RectTransform>();
        PlanetController planetControllerScript = chosenPlanet.GetComponent<PlanetController>();
        PlanetDisplay planetDisplayScript = chosenPlanet.GetComponent<PlanetDisplay>();

        // Set this planet to the global "size" position and scale
        planetRectTransform.anchoredPosition = new Vector2(planetControllerScript.sizeModeX, planetControllerScript.sizeModeY);
        imageObj.transform.localScale = new Vector2(planetDisplayScript.sizeModeScale, planetDisplayScript.sizeModeScale);

        // Set the name object back to the Size Mode position
        nameRectTransform.anchoredPosition = planetDisplayScript.sizeModeNameVector;//new Vector2(planetDisplayScript.sizeModeNameX,sizeMode;

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
