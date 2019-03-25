using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{
    Button thisButton;

    void Awake()
    {
        // Initialize button reference
        thisButton = gameObject.GetComponent<Button>();

        // If mini planet, change the colours of the buttons
        if (GameController.currentMode == "DistanceMode" && gameObject.name != "Distance Planet")
        {
            // Initialize button colours
            var colourNormal = new Color32(200, 200, 200, 125);
            var colourHighlight = new Color32(225, 225, 225, 200);
            var colourDisabled = new Color32(255, 255, 255, 255);
            var buttonColors = thisButton.colors;

            buttonColors.normalColor = colourNormal;
            buttonColors.highlightedColor = colourHighlight;
            buttonColors.disabledColor = colourDisabled;

            thisButton.colors = buttonColors;
        }
    }

    // Enable this button
    public void ButtonEnable()
    {
        thisButton.interactable = true;
    }
    // Disable this button
    public void ButtonDisable()
    {
        thisButton.interactable = false;
    }
}
