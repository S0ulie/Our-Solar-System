using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDistance : MonoBehaviour
{
    static public float myScale;
    static public float myDefaultScale;
    static public double kmCounter;
    Text counterText;

    // Initialize the Counter
    void Awake()
    {
        myDefaultScale = 0f;
        myScale = myDefaultScale;
        transform.localScale = new Vector2(myScale, myScale);

        kmCounter = 0f;

        counterText = gameObject.GetComponent<Text>();
        counterText.text = kmCounter.ToString("F") + " million km";
    }

    // Update the scale and text of the Counter
    void Update()
    {
        counterText.text = kmCounter.ToString("F1") + " million km";
        transform.localScale = new Vector2(myScale, myScale);
    }
}
