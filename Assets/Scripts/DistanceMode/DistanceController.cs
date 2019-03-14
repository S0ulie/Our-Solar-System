using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{
    public static GameObject distanceObj;
    public static GameObject kmCounterObj;
    public static GameObject journeyObj;
    public static GameObject journeyFromObj;
    public static GameObject journeyToObj;

    public static DistanceController Instance;

    void Awake()
    {
        // Initialize Singleton
        Instance = this;

        // Get a reference to the distance planet
        distanceObj = GameObject.Find("Distance Planet");

        // Get a reference to Distance Counter object
        kmCounterObj = GameObject.Find("Distance Counter");

        // Get a reference to Journey Display objects
        journeyObj = GameObject.Find("Journey Display");
        journeyFromObj = journeyObj.transform.Find("Journey From").gameObject;
        journeyToObj = journeyObj.transform.Find("Journey To").gameObject;
    }
    void Start()
    {
        // Deactivate display objects
        DeactivateCounter();
        DeactivateJourneyDisplay();
    }

    // COUNTER FUNCTIONS
    public void ActivateCounter()
    {
        kmCounterObj.SetActive(true);
    }
    public void DeactivateCounter()
    {
        kmCounterObj.SetActive(false);
    }
    public void ResetCounter()
    {
        CountDistance.myScale = CountDistance.myDefaultScale;
        kmCounterObj.transform.localScale = new Vector2(CountDistance.myScale, CountDistance.myScale);
        CountDistance.kmCounter = 0f;
    }

    // JOURNEY DISPLAY FUNCTIONS
    public void DeactivateJourneyDisplay()
    {
        journeyObj.SetActive(false);
    }
    public void ActivateJourneyDisplay()
    {
        journeyObj.SetActive(true);
    }
    public void SetJourneyDisplay(string fromPlanet, string toPlanet)
    {
        // Reset the scale to 0
        JourneyDisplay.myScale = 0f;

        // Set the text of the objects to the new planet names
        journeyFromObj.GetComponent<Text>().text = fromPlanet;
        journeyToObj.GetComponent<Text>().text = toPlanet;
    }
}