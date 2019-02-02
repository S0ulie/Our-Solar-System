using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetController : MonoBehaviour
{
    // Declare the size mode co-ords and scale
    public float sizeModeX;
    public float sizeModeY;
    RectTransform planetRectTransform;
    RectTransform nameRectTransform;

    // Declare references to planet's child objects
    GameObject planetNameObject;
    GameObject planetImageObject;
    string planetNameText;

    void Start()
    {
        // Get the RectTransform from this game object
        planetRectTransform = GetComponent<RectTransform>();

        // Get the starting versions of the size mode co-ords and scale
        sizeModeX = planetRectTransform.anchoredPosition.x;
        sizeModeY = planetRectTransform.anchoredPosition.y;

        // Set a reference to the child objects, Name and Image;
        planetNameObject = gameObject.transform.Find("Name").gameObject;
        planetImageObject = gameObject.transform.Find("Image").gameObject;

        nameRectTransform = planetNameObject.GetComponent<RectTransform>();
    }

    // When this planet has been chosen by the player
    public void onClickPlanet()
    {
        // Get the planet name from the name object
        planetNameText = planetNameObject.GetComponent<Text>().text;

        // Set this planet as the chosen planet
        PlanetsInit.chosenPlanet = planetNameText;

        PlanetDisplay planetDisplayScript =  gameObject.GetComponent<PlanetDisplay>();
        Vector2 sizeModeNameVector = planetDisplayScript.sizeModeNameVector;
        /*
        var nameX = planetDisplayScript.sizeModeNameX;
        var nameY = planetDisplayScript.sizeModeNameY;
        var diameter = planetDisplayScript.diameterInPixels;
        */
        var nameX = nameRectTransform.anchoredPosition.x;
        nameRectTransform.anchoredPosition = new Vector2(nameX, PlanetsInit.infoNameY);// sizeModeNameVector;


        planetImageObject.transform.localScale = new Vector2(4, 4);//sizeModeScale, sizeModeScale);

        // Set this position to the global Planet Info position
        planetRectTransform.anchoredPosition = new Vector2(PlanetsInit.infoX, PlanetsInit.infoY);

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
        planetNameText = planetNameObject.GetComponent<Text>().text;

        // If this planet has been initialized
        if (planetNameText != "unintialized")
        {
            // If a planet has been chosen and is not the current planet's name
            if (PlanetsInit.chosenPlanet != "none" && PlanetsInit.chosenPlanet != planetNameText)
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
