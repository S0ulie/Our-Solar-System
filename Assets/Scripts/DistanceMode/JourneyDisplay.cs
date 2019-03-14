using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyDisplay : MonoBehaviour
{
    static public float myScale;

    // Initialize the scale variable
    void Start()
    {
        myScale = 0f;
        transform.localScale = new Vector2(myScale, myScale);
    }

    // Update the Journey Display's scale
    void Update()
    {
        transform.localScale = new Vector2(myScale, myScale);
    }
}
