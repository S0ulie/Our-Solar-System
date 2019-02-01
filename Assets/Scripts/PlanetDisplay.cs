using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetDisplay : MonoBehaviour
{
    public Planet planet;

    public Text nameText;
    public Text descriptionText;

    public Image graphicSprite;

    public Text diameterText;
    public Text temperatureText;
    public Text gravityText;
    public Text numMoonsText;

    public float thisPlanetScale;


    // Use this for initialization
    void Start ()
    {
        // Set the UI Name's text to the scriptable planet's name
        nameText.text = planet.name;
        // Set the UI image to the scriptable planet's sprite
        graphicSprite.sprite = planet.graphic;

        // Use the scriptable planet's name to look up the corresponding stats
        PlanetStats thisPlanet = PlanetsInit.planetstats[planet.name];

        // Set the rest of the UI objects to the planet's stats
        descriptionText.text = thisPlanet.description;
        diameterText.text = "Diameter: " + thisPlanet.diameter.ToString() + " km";
        temperatureText.text = "Average Temperature: " + thisPlanet.temperature.ToString() + " °C";
        gravityText.text = "Gravity: " + thisPlanet.gravity.ToString() + " m/s²";
        numMoonsText.text = "Number of Moons: " + thisPlanet.numMoons.ToString();

        // Get the pixels per unit of the sprite being used
        var tempObj = transform.Find("Image");
        float ppu = graphicSprite.sprite.pixelsPerUnit;

        // Set the scale of the planet relative to it's diameter
        float diameterInPixels = thisPlanet.diameter * PlanetsInit.pixelsPerKm;
        thisPlanetScale = diameterInPixels / ppu;
        tempObj.transform.localScale = new Vector2(thisPlanetScale, thisPlanetScale);

        // Keep the name above the scaled planet
        tempObj = transform.Find("Name");
        RectTransform planetRectTransform = tempObj.GetComponent<RectTransform>();
        float tempX = planetRectTransform.anchoredPosition.x;
        float tempY = planetRectTransform.anchoredPosition.y;
        planetRectTransform.anchoredPosition = new Vector2(tempX, tempY + 0.45f * diameterInPixels);

        // Keep the description below the planet
        tempObj = transform.Find("Description");
        planetRectTransform = tempObj.GetComponent<RectTransform>();
        tempX = planetRectTransform.anchoredPosition.x;
        tempY = planetRectTransform.anchoredPosition.y;
        planetRectTransform.anchoredPosition = new Vector2(tempX, tempY - 0.3f * diameterInPixels);


    }
}
