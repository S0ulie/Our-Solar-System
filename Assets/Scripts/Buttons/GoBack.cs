using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    public void goBack()
    {
        // Get the chosen planet object
        GameObject chosenPlanet = GameObject.Find(GameController.chosenPlanet);
        
        
        // Reset the planets back to the current mode's settings

        // If Size Mode do reset to size mode
        chosenPlanet.GetComponent<PlanetController>().ResetPlanet();

        // If Distance Mode do reset to distance mode

        // Deactivate the button
        gameObject.SetActive(false);
    }
}
