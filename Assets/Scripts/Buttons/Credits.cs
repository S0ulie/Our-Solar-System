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
    }


    // CREDITS CLICK
    public void onClickCredits()
    {
        // Fade to Credits scene
        LevelChanger.Instance.FadeToLevel(levelIndexCredits);
        // Load credits screen
        //StartCoroutine(CreditsInfo());
    }
    /*
    IEnumerator CreditsInfo()
    {
        // Fade out
        LevelChanger.Instance.FadeOut();

        yield return new WaitForSeconds(0.5f);

        // Fade to Credits scene
        LevelChanger.Instance.FadeToLevel(levelIndexCredits);
    }
    */

}
