using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// Initialize and control the interactions with this planet
public class PlanetController : MonoBehaviour
{
    // Declare Variables
    GameObject planetNameObject;
    GameObject planetImageObject;
    RectTransform planetRectTransform;
    RectTransform nameRectTransform;
    Sprite planetSprite;

    public string currentMode;
    public float diameterInPixels;
    public float ppu;
    public float thisModeX;
    public float thisModeY;
    public float thisModeScale;

    public float thisModeNameX;
    public float thisModeNameY;
    public Vector2 thisModeNameVector;
    string planetNameText;

    GameObject distanceObj;

    // SETUP PLANET
    public void PlanetSetup(PlanetStats thisPlanet)
    {
        // Initialize Variables


        // Set a reference to the child objects, Name and Image;
        planetNameObject = gameObject.transform.Find("Name").gameObject;
        planetImageObject = gameObject.transform.Find("Image").gameObject;

        // Get the RectTransform of this planet and it's name object.
        planetRectTransform = GetComponent<RectTransform>();
        nameRectTransform = planetNameObject.GetComponent<RectTransform>();

        // Get the starting versions of this Mode's co-ords and scale
        thisModeX = planetRectTransform.anchoredPosition.x;
        thisModeY = planetRectTransform.anchoredPosition.y;

        // Get the pixels per unit of the sprite being used
        ppu = planetImageObject.GetComponent<Image>().sprite.pixelsPerUnit;


        // Setup the objects in accordance with the current mode
        currentMode = GameController.currentMode;//GameObject.Find("SolarSystemInit").GetComponent<GameController>().currentMode;
        if (currentMode == "ScaleMode")
        {
            // Set the scale of the planet relative to it's diameter
            diameterInPixels = thisPlanet.diameter * GameController.pixelsPerKm;
            thisModeScale = diameterInPixels / ppu;
            planetImageObject.transform.localScale = new Vector2(thisModeScale, thisModeScale);

            // Keep the name above the scaled planet
            nameRectTransform = planetNameObject.GetComponent<RectTransform>();
            thisModeNameX = nameRectTransform.anchoredPosition.x;
            thisModeNameY = nameRectTransform.anchoredPosition.y;
            nameRectTransform.anchoredPosition = new Vector2(thisModeNameX, thisModeNameY + GameController.textScalar * diameterInPixels);

        }
        // Setup the distance mode planet to be standard size
        else if (gameObject.name == "Distance Planet")
        {

            // Set this planet's name text position to the Planet Info version
            var nameX = nameRectTransform.anchoredPosition.x;
            nameRectTransform.anchoredPosition = new Vector2(nameX, GameController.infoNameY);

            // Set this planet's position and scale to the default version
            planetRectTransform.anchoredPosition = new Vector2(GameController.defaultX, GameController.defaultY);
            planetImageObject.transform.localScale = new Vector2(GameController.defaultScale, GameController.defaultScale);
        }
        else if (currentMode == "DistanceMode")
        {
            // Initialize the reference to the Distance Planet
            distanceObj = MenuController.distanceObj;
        }

            // Save vector to variable for future use
            thisModeNameVector = nameRectTransform.anchoredPosition;

    }


    // PLANET CLICK
    public void onClickPlanet()
    {
        // If clicking on any planet in Scale Mode or Distance Planet, get that planet's info
        if (currentMode == "ScaleMode" || gameObject.name == "Distance Planet")
        {
            // Get this planet's name text from the name object
            planetNameText = planetNameObject.GetComponent<Text>().text;

            // Set this planet as the chosen planet
            if (currentMode == "ScaleMode")
                GameController.chosenPlanet = planetNameText;
            else
                GameController.chosenPlanet = gameObject.name;

            // Set this planet's name text position to the Planet Info version
            var nameX = nameRectTransform.anchoredPosition.x;
            nameRectTransform.anchoredPosition = new Vector2(nameX, GameController.infoNameY);

            // Set this planet's position and scale to the default version
            planetRectTransform.anchoredPosition = new Vector2(GameController.defaultX, GameController.defaultY);
            planetImageObject.transform.localScale = new Vector2(GameController.defaultScale, GameController.defaultScale);

            // Enable all the text objects
            gameObject.transform.Find("Description").gameObject.SetActive(true);
            gameObject.transform.Find("Diameter").gameObject.SetActive(true);
            gameObject.transform.Find("Temperature").gameObject.SetActive(true);
            gameObject.transform.Find("Gravity").gameObject.SetActive(true);
            gameObject.transform.Find("NumMoons").gameObject.SetActive(true);

            // Disable the "Switch" button
            GameController.buttonSwitch.gameObject.SetActive(false);

            // Enable the "Go Back" button
            GameController.buttonBack.gameObject.SetActive(true);
        }
        // If clicking on a mini planet in Distance Mode, travel to that planet
        else if (currentMode == "DistanceMode")
        {
            // Make Distance Planet move/Tween off of the screen (Lerp?)
            distanceObj.GetComponent<PlanetController>().StartCoroutine(TravelToPlanet(gameObject.name));
            //transform.DOMoveX(Screen.width + transform.localScale.x * ppu, 2);
            //transform.DOMove(new Vector3(2, 2, 2), 1);
            // Start counting up a distance number
        }
    }

    // TRAVEL TO PLANET
    // Handle the sequence of events for travelling to a new planet
    IEnumerator TravelToPlanet(string planetName)
    {
        // Tween Distance Planet offscreen to the right
        float halfPlanetWidth = GameController.defaultScale * ppu * 0.5f;
        Tween movePlanetX = transform.DOMoveX(Screen.width + halfPlanetWidth, 0.75f).SetEase(Ease.InQuart);
        yield return movePlanetX.WaitForCompletion();

        // Number counter

        // Get the distance from the sun of this planet
        var oldKmFromSun = GetComponent<PlanetImport>().kmFromSun;

        // Change to new planet
        //GetComponent<PlanetImport>().planet = 

        // Calculate the distance between new planet and current planet
        var newKmFromSun = GetComponent<PlanetImport>().kmFromSun;
        // Convert distance to a time using ratio e.g. 100,000 KM = 1 second

        // PRINT A PLANET'S DISTANCE FROM SUN
        Debug.Log("distance from sun = " + "something" + " million km");

        // Show counter text
        // Ease in and out over time from 0 -> calculated distance


        // Tween new Distance Planet onscreen from the left.
        transform.position = new Vector3(0 - halfPlanetWidth, transform.position.y, 0);
        movePlanetX = transform.DOMoveX(Screen.width * 0.5f, 0.75f).SetEase(Ease.OutQuart);

        //yield return new WaitForSeconds(1.0f);
    }

    // RESET PLANET
    public void ResetPlanet()
    {
        // Get the RectTransform from this planet object
        RectTransform planetRectTransform = GetComponent<RectTransform>();
        RectTransform nameRectTransform = planetNameObject.GetComponent<RectTransform>();

        if (currentMode == "ScaleMode")
        {
            // Set this planet to this Mode's position and scale
            planetRectTransform.anchoredPosition = new Vector2(thisModeX, thisModeY);
            planetImageObject.transform.localScale = new Vector2(thisModeScale, thisModeScale);

            // Set this planet's name object back to this Mode's position
            nameRectTransform.anchoredPosition = thisModeNameVector;
        }

        // Deactivate all the text objects and the collider belonging to this planet
        transform.Find("Description").gameObject.SetActive(false);
        transform.Find("Diameter").gameObject.SetActive(false);
        transform.Find("Temperature").gameObject.SetActive(false);
        transform.Find("Gravity").gameObject.SetActive(false);
        transform.Find("NumMoons").gameObject.SetActive(false);

        // Set the chosen planet back to none
        GameController.chosenPlanet = "none";
    }

    // UPDATE FUNCTION
    void Update()
    {
        // CHECK CHOSEN - Check if a planet has been chosen by the player

        // Get planet's name from the name object
        planetNameText = planetNameObject.GetComponent<Text>().text;

        // If this planet has been initialized
        if (planetNameText != "unintialized")
        {
            // Disable other planets for Planet Info
            bool disableBool = false;
            switch (currentMode)
            {
                case "ScaleMode":
                    // Disable this planet if not the chosen planet
                    if (GameController.chosenPlanet != "none" && GameController.chosenPlanet != planetNameText)
                        disableBool = true;
                    break;

                case "DistanceMode":
                    // Disable this planet unless it's the Distance Mode planet.
                    if (GameController.chosenPlanet != "none" && gameObject.name != "Distance Planet")
                        disableBool = true;
                    break;
            }
            if (disableBool)
            {
                // Disable this planet's name, image, and collider
                planetNameObject.SetActive(false);
                planetImageObject.SetActive(false);
                gameObject.transform.Find("MinColliderBox").gameObject.SetActive(false);

            }
            // Otherwise no planet has been selected so set as active if not already;
            else if (planetImageObject.activeSelf == false)
            {
                planetNameObject.SetActive(true);
                planetImageObject.SetActive(true);
                gameObject.transform.Find("MinColliderBox").gameObject.SetActive(true);
            }
        }
    }

}
