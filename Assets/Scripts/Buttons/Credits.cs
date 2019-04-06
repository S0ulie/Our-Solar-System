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
        // Play "Switch Mode" button sound
        AudioController.Instance.PlaySfx(AudioController.audioSwitchMode);

        // Fade to Credits scene
        LevelChanger.Instance.FadeToLevel(levelIndexCredits);
    }

}
