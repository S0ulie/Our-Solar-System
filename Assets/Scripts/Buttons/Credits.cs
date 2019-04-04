using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public int levelIndexCredits;

    void Awake()
    {
        // Initialize button
        GameController.buttonCredits = gameObject;

        // Store the credits scene index in a variable
        levelIndexCredits = 3;
        Debug.Log("Initial credits index =" + levelIndexCredits);
    }


    // PLANET CLICK
    public void onClickCredits()
    {

        // Load credits screen
        StartCoroutine(CreditsInfo());
    }
    IEnumerator CreditsInfo()
    {
        // Fade out
        LevelChanger.Instance.FadeOut();

        yield return new WaitForSeconds(0.5f);

        // Switch to Credits scene

        // Enable the "Go Back" button
        GameController.buttonBack.gameObject.SetActive(true);

        Debug.Log("Credits index within coroutine =" + levelIndexCredits);
        // Fade to Credits scene
        LevelChanger.Instance.FadeToLevel(levelIndexCredits);
    }
    

}
