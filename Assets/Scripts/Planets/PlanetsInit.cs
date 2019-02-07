using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Initialize the Game/Solar System
public class PlanetsInit : MonoBehaviour
{

    // Fraction of screen height used by biggest planet
    [SerializeField] float maxHeightUsed;

    // pixels per KM will help us scale the planets correctly
    public static float pixelsPerKm;

    // Declare a dictionary to store the planets' statistics
    public static Dictionary<string, PlanetStats> planetstats;

    // Keep track of whether a planet has been chosen by the player.
    public static string chosenPlanet = "none";

    // Set the global Size Mode scalar constant
    public static float sizeModeScalar = 0.45f;

    // Set the global Planet Info position, scale, and name
    public static float infoX = 0f;
    public static float infoY = 0f;
    public static float infoModeScale = 4f;

    // Set the global Info Mode Name position y
    public static float infoNameY = 250f;

    public static GameObject button;

    // This is the fraction of the screen we want a planet to take up when showing description
    [SerializeField] public static float descriptScale = 2f; //0.9f

    // Use this for initialization
    void Awake()
    {
        // Populate the planetstats dictionary
        planetstats = new Dictionary<string, PlanetStats>();

        PlanetStats mercuryStats = new PlanetStats("Mercury", "Mercury has very little atmosphere.", 4878, 167, 3.7f, 0);
        PlanetStats venusStats = new PlanetStats("Venus", "Venus spins backwards compared to other planets.", 12100, 464, 8.9f, 0);
        PlanetStats earthStats = new PlanetStats("Earth", "Our home planet.", 12742, 15, 9.8f, 1);
        PlanetStats marsStats = new PlanetStats("Mars", "Mars is the closest planet to our home.", 6779, -65, 3.7f, 2);
        PlanetStats jupiterStats = new PlanetStats("Jupiter", "Jupiter is the biggest planet in our solar system.", 142981, -110, 23.1f, 79);
        PlanetStats saturnStats = new PlanetStats("Saturn", "Saturn has winds that reach up to 500 meters per second.", 120536, -140, 9.0f, 62);
        PlanetStats uranusStats = new PlanetStats("Uranus", "Uranus is a gas giant that spins backwards like Venus.", 51118, -195, 8.7f, 27);
        PlanetStats neptuneStats = new PlanetStats("Neptune", "Neptune has the second largest gravity - second only to Jupiter.", 49500, -200, 11f, 14);

        planetstats.Add("Mercury", mercuryStats);
        planetstats.Add("Venus", venusStats);
        planetstats.Add("Earth", earthStats);
        planetstats.Add("Mars", marsStats);
        planetstats.Add("Jupiter", jupiterStats);
        planetstats.Add("Saturn", saturnStats);
        planetstats.Add("Uranus", uranusStats);
        planetstats.Add("Neptune", neptuneStats);

        // The maximum diameter of a planet in pixels
        float maxDiameterPixels = Screen.height * maxHeightUsed;

        // Divide maxDiameter by biggest planet = num pixels per km
        pixelsPerKm = maxDiameterPixels / planetstats["Jupiter"].diameter;

        // Initialize button
        button = GameObject.Find("Go Back Button");
        button.gameObject.SetActive(false);
    }
}