using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Import the planet information from a scriptable planet object
public class PlanetImport : MonoBehaviour
{
    public Planet planet;

    public Text nameText;
    public Text descriptionText;

    public Image graphicSprite;

    public Text diameterText;
    public Text temperatureText;
    public Text gravityText;
    public Text numMoonsText;
    public double kmFromSun;

    public PlanetStats thisPlanet;

    void Start()
    {
        // Set the UI Name's text to the scriptable planet's name
        nameText.text = planet.name;
        // Set the UI image to the scriptable planet's sprite
        graphicSprite.sprite = planet.graphic;

        // Use the scriptable planet's name to look up the corresponding stats
        thisPlanet = GameController.planetstats[planet.name];

        // Set the rest of this planet's child objects to the planet's stats
        descriptionText.text = thisPlanet.description;
        diameterText.text = "Diameter: " + thisPlanet.diameter.ToString() + " km";
        temperatureText.text = "Average Temperature: " + thisPlanet.temperature.ToString() + " °C";
        gravityText.text = "Gravity: " + thisPlanet.gravity.ToString() + " m/s²";
        numMoonsText.text = "Number of Moons: " + thisPlanet.numMoons.ToString();

        // Set the extra stats
        kmFromSun = thisPlanet.kmFromSun;

        // Setup the planet
        GetComponent<PlanetController>().PlanetSetup(thisPlanet);
    }
}
