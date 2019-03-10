using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDistance : MonoBehaviour
{
    Text counterText;
    static public double kmCounter;

    void Start()
    {
        kmCounter = 0;
        counterText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = kmCounter.ToString();
        // Not working?
    }
}
