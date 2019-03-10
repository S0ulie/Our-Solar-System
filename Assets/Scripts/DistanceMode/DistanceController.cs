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
            //Debug.Log("Before" + GameObject.Find("Distance Counter"));
            kmCounterObj = GameObject.Find("Distance Counter");
            //kmCounterObj.SetActive(false);
            //Debug.Log("after" + kmCounterObj);

    }

    public void ActivateCounter()
    {
        kmCounterObj.SetActive(true);
    }
}