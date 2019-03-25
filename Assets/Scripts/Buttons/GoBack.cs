using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    void Awake()
    {
        //Initialize button
        GameController.buttonBack = gameObject;
        gameObject.SetActive(false);
    }

    public void goBack()
    {
        // Play Go back button sound
        AudioController.Instance.PlaySfx(AudioController.audioGoBack);

        // Return back to previous mode
        StartCoroutine(FadeToMode());
    }
    IEnumerator FadeToMode()
    {
        // Fade out
        LevelChanger.Instance.FadeOut();

        yield return new WaitForSeconds(LevelChanger.Instance.fadeTime);

        // Get the chosen planet object
        GameObject chosenPlanet = GameObject.Find(GameController.chosenPlanet);

        // Reset the planets
        chosenPlanet.GetComponent<PlanetController>().ResetPlanet();

        // Disable the "Go Back" button
        gameObject.SetActive(false);

        // Enable the "Switch" button
        GameController.buttonSwitchMode.SetActive(true);

        // Activate Counters
        if (GameController.currentMode == "DistanceMode")
        {
            DistanceController.Instance.ActivateCounter();
            DistanceController.Instance.ActivateJourneyDisplay();
        }

        // Fade in
        LevelChanger.Instance.FadeIn();
    }
}
