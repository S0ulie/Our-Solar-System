using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Initialize and control the interactions with this planet
public class PlanetController : MonoBehaviour
{
    // Declare Variables
    GameObject planetNameObject;
    GameObject planetImageObject;
    RectTransform planetRectTransform;
    RectTransform nameRectTransform;
    Sprite planetSprite;

    public float diameterInPixels;
    public float sizeModeX;
    public float sizeModeY;
    public float sizeModeScale;

    public float sizeModeNameX;
    public float sizeModeNameY;
    public Vector2 sizeModeNameVector;
    string planetNameText;

    // Setup this planet
    public void PlanetSetup(PlanetStats thisPlanet)
    {
        // Initialize Variables

        // Set a reference to the child objects, Name and Image;
        planetNameObject = gameObject.transform.Find("Name").gameObject;
        planetImageObject = gameObject.transform.Find("Image").gameObject;

        // Get the RectTransform of this planet and it's name object.
        planetRectTransform = GetComponent<RectTransform>();
        nameRectTransform = planetNameObject.GetComponent<RectTransform>();

        // Get the starting versions of the size mode co-ords and scale
        sizeModeX = planetRectTransform.anchoredPosition.x;
        sizeModeY = planetRectTransform.anchoredPosition.y;

        // Get the pixels per unit of the sprite being used
        float ppu = planetImageObject.GetComponent<Image>().sprite.pixelsPerUnit;


        // Setup the objects

        // Set the scale of the planet relative to it's diameter
        diameterInPixels = thisPlanet.diameter * GameController.pixelsPerKm;
        sizeModeScale = diameterInPixels / ppu;
        planetImageObject.transform.localScale = new Vector2(sizeModeScale, sizeModeScale);

        // Keep the name above the scaled planet
        nameRectTransform = planetNameObject.GetComponent<RectTransform>();
        sizeModeNameX = nameRectTransform.anchoredPosition.x;
        sizeModeNameY = nameRectTransform.anchoredPosition.y;
        nameRectTransform.anchoredPosition = new Vector2(sizeModeNameX, sizeModeNameY + GameController.sizeModeScalar * diameterInPixels);

        // Save vector to variable for future use
        sizeModeNameVector = nameRectTransform.anchoredPosition;
    }

    // When this planet has been chosen by the player, show this Planet's Info
    public void onClickPlanet()
    {
        // Get this planet's name text from the name object
        planetNameText = planetNameObject.GetComponent<Text>().text;

        // Set this planet as the chosen planet
        GameController.chosenPlanet = planetNameText;

        // Set this planet's name text position to the Planet Info version
        var nameX = nameRectTransform.anchoredPosition.x;
        nameRectTransform.anchoredPosition = new Vector2(nameX, GameController.infoNameY);

        // Set this planet's position and scale to the Planet Info version
        planetRectTransform.anchoredPosition = new Vector2(GameController.infoX, GameController.infoY);
        planetImageObject.transform.localScale = new Vector2(GameController.infoModeScale, GameController.infoModeScale);

        // Enable all the text objects
        gameObject.transform.Find("Description").gameObject.SetActive(true);
        gameObject.transform.Find("Diameter").gameObject.SetActive(true);
        gameObject.transform.Find("Temperature").gameObject.SetActive(true);
        gameObject.transform.Find("Gravity").gameObject.SetActive(true);
        gameObject.transform.Find("NumMoons").gameObject.SetActive(true);

        // Enable the "Go Back" button
        GameController.button.gameObject.SetActive(true);
    }

    public void SetToSizeMode()
    {
        // Get the RectTransform from this planet object
        RectTransform planetRectTransform = GetComponent<RectTransform>();
        RectTransform nameRectTransform = planetNameObject.GetComponent<RectTransform>();

        // Set this planet to the Size Mode position and scale
        planetRectTransform.anchoredPosition = new Vector2(sizeModeX, sizeModeY);
        planetImageObject.transform.localScale = new Vector2(sizeModeScale, sizeModeScale);

        // Set this planet's name object back to the Size Mode position
        nameRectTransform.anchoredPosition = sizeModeNameVector;//new Vector2(PlanetImportScript.sizeModeNameX,sizeMode;

        // Deactivate all the text objects belonging to this planet
        transform.Find("Description").gameObject.SetActive(false);
        transform.Find("Diameter").gameObject.SetActive(false);
        transform.Find("Temperature").gameObject.SetActive(false);
        transform.Find("Gravity").gameObject.SetActive(false);
        transform.Find("NumMoons").gameObject.SetActive(false);

        // Set the chosen planet back to none
        GameController.chosenPlanet = "none";
    }

    void Update()
    {
        // Check if a planet has been chosen by the player

        // Get planet's name from the name object
        planetNameText = planetNameObject.GetComponent<Text>().text;

        // If this planet has been initialized
        if (planetNameText != "unintialized")
        {
            // If a planet has been chosen and is not the current planet's name
            if (GameController.chosenPlanet != "none" && GameController.chosenPlanet != planetNameText)
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
