using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {

    string activeSceneName;

    void Awake()
    {
        //Initialize button
        GameController.buttonBack = gameObject;

        // Set inactive except for credits scene
        activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName != "Credits")
            gameObject.SetActive(false);
    }

    public void goBack()
    {
        // Play Go back button sound
        AudioController.Instance.PlaySfx(AudioController.audioGoBack);

        // If normal scene, return back to previous mode
        if (activeSceneName != "Credits")
            StartCoroutine(FadeToMode());

        // If credits scene, go back to previous scene
        else
            LevelChanger.Instance.FadeToLevel(LevelChanger.levelIndexPrev);
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

        // Enable the "Switch Mode" button
        if (GameController.buttonCredits != null)
            GameController.buttonSwitchMode.SetActive(true);

        // Enable the "Credits" button
        if (GameController.buttonCredits != null)
            GameController.buttonCredits.gameObject.SetActive(true);

        // Disable the "Go Back" button
        if (GameController.buttonCredits != null)
            gameObject.SetActive(false);

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
