using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public static GameObject distanceObj;
    public static GameObject kmCounterObj;

    void Awake()
    {
        // Get a reference to the distance planet
        distanceObj = GameObject.Find("Distance Planet");

        // Get a reference to Distance Counter object
        kmCounterObj = GameObject.Find("Distance Counter");
    }
    void Start()
    {
        DeactivateCounter();
    }


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
}