using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetController : MonoBehaviour
{
    // Declare the size mode co-ords
    public float sizeModeX;
    public float sizeModeY;
    RectTransform planetRectTransform;

    // Declare references to planet's child objects
    GameObject planetNameObject;
    GameObject planetImageObject;
    string planetName;

    void Start()
    {
        // Get the RectTransform from this game object
        planetRectTransform = GetComponent<RectTransform>();
        // Set the size mode co-ords to the starting co-ords
        sizeModeX = planetRectTransform.anchoredPosition.x;
        sizeModeY = planetRectTransform.anchoredPosition.y;

        // Set a reference to the child objects, Name and Image;
        planetNameObject = gameObject.transform.Find("Name").gameObject;
        planetImageObject = gameObject.transform.Find("Image").gameObject;

    }

    // When this planet has been chosen by the player
    public void onClickPlanet()
    {
        // Get the planet name from the name object
        planetName = planetNameObject.GetComponent<Text>().text;

        // Set this planet as the chosen planet
        PlanetsInit.chosenPlanet = planetName;

        // Set this position to the global "description" position
        planetRectTransform.anchoredPosition = new Vector2(PlanetsInit.descriptX, PlanetsInit.descriptY);

        // Enable all the text objects
        gameObject.transform.Find("Description").gameObject.SetActive(true);
        gameObject.transform.Find("Diameter").gameObject.SetActive(true);
        gameObject.transform.Find("Temperature").gameObject.SetActive(true);
        gameObject.transform.Find("Gravity").gameObject.SetActive(true);
        gameObject.transform.Find("NumMoons").gameObject.SetActive(true);

        // Enable the "Go Back" button
        PlanetsInit.button.gameObject.SetActive(true);
    }

    void Update()
    {
        // ----- Check if a planet has been chosen by the player -----

        // Get planet's name from the name object
        planetName = planetNameObject.GetComponent<Text>().text;

        // If this planet has been initialized
        if (planetName != "unintialized")
        {
            // If a planet has been chosen and is not the current planet's name
            if (PlanetsInit.chosenPlanet != "none" && PlanetsInit.chosenPlanet != planetName)
            {
                // Disable this planet's name and image
                planetNameObject.SetActive(false);
                planetImageObject.SetActive(false);

            }
            // Otherwise no planet has been selected so set as active if not already;
            else if (planetImageObject.activeSelf == false)
            {
                planetNameObject.SetActive(true);
                planetImageObject.SetActive(true);
            }
        }
    }

}
