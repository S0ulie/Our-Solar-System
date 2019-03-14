using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Initialize the Game/Solar System
public class GameController : MonoBehaviour
{

    // Fraction of screen height used by biggest planet
    [SerializeField] float maxHeightUsed;

    // pixels per KM will help us scale the planets correctly
    public static float pixelsPerKm;

    // Declare a dictionary to store the planets' statistics
    public static Dictionary<string, PlanetStats> planetstats;

    // Current Solar System Mode
    public static string currentMode;

    // Keep track of whether a planet has been chosen by the player.
    public static string chosenPlanet = "none";

    // Keep track of whether a planet is moving
    public static bool planetIsMoving = false;

    // Set the global Planet name position scalar
    public static float textScalar = 0.45f;

    // Set the global default planet position and name
    public static float defaultX = 0f;
    public static float defaultY = -50f;
    public static float kmPlanetY = 25f;
    public static float defaultScale = 4f;

    // Set the global Info Mode Name position y
    public static float infoNameY = 250f;

    // Create Variables for future references to buttons
    public static GameObject buttonSwitch;
    public static GameObject buttonBack;

    // This is the fraction of the screen we want a planet to take up when showing description
    [SerializeField] public static float descriptScale = 2f; //0.9f

    // Use this for initialization
    void Awake()
    {
        // This is a persistent object
        DontDestroyOnLoad(this.gameObject);

        // Set the current Solar System Viewing Mode (should always start with Scale Mode)
        currentMode = "ScaleMode";
        // Load the viewing mode
        SceneManager.LoadScene(currentMode);

        // Populate the planetstats dictionary
        planetstats = new Dictionary<string, PlanetStats>();

        PlanetStats mercuryStats = new PlanetStats("Mercury", "Mercury has very little atmosphere.", 4878, 167, 3.7f, 0, 57.9d);
        PlanetStats venusStats = new PlanetStats("Venus", "Venus spins backwards compared to other planets.", 12100, 464, 8.9f, 0, 108.2d);
        PlanetStats earthStats = new PlanetStats("Earth", "Our home planet.", 12742, 15, 9.8f, 1, 149.6d);
        PlanetStats marsStats = new PlanetStats("Mars", "Mars is the closest planet to our home.", 6779, -65, 3.7f, 2, 227.9d);
        PlanetStats jupiterStats = new PlanetStats("Jupiter", "Jupiter is the biggest planet in our solar system.", 142981, -110, 23.1f, 79, 778.3d);
        PlanetStats saturnStats = new PlanetStats("Saturn", "Saturn has winds that reach up to 500 meters per second.", 120536, -140, 9.0f, 62, 1427d);
        PlanetStats uranusStats = new PlanetStats("Uranus", "Uranus is a gas giant that spins backwards like Venus.", 51118, -195, 8.7f, 27, 2871d);
        PlanetStats neptuneStats = new PlanetStats("Neptune", "Neptune has the second largest gravity - second only to Jupiter.", 49500, -200, 11f, 14, 4497d);

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

    }
}