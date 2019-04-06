using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // DECLARE
    // Create a singleton for easy access
    public static AudioController Instance;

    // Music
    AudioClip audioMusic;

    // Sfx
    public static AudioClip audioClickPlanet;
    public static AudioClip audioGoBack;
    public static AudioClip audioTravelShort;
    public static AudioClip audioTravelLong;
    public static AudioClip audioSwitchMode;

    // Audio players
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;

    // Fade Out Bool
    bool isFadingOut = false;

    // Initialize Singleton and audio clips
    void Awake()
    {
        #region Singleton

        Instance = this;

        #endregion

        audioMusic = Resources.Load("Music/The_Infinite") as AudioClip;

        audioClickPlanet = Resources.Load("SFX/Buttons/Button_4_pack2") as AudioClip;
        audioGoBack = Resources.Load("SFX/Buttons/Button_22_pack2") as AudioClip;
        audioTravelShort = Resources.Load("SFX/Appear-Cut") as AudioClip;
        audioTravelLong = Resources.Load("SFX/Appear") as AudioClip;
        audioSwitchMode = Resources.Load("SFX/Buttons/Button_8_pack2") as AudioClip;
    }

    // Initialize audio players
    void Start()
    {
        musicPlayer = AddAudio(true, false, 0.15f);
        sfxPlayer = AddAudio(false, false, 1.0f);

        // Start Music
        musicPlayer.clip = audioMusic;
        musicPlayer.Play();
    }

    // Create an audio source
    public AudioSource AddAudio(bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>(); 
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    // Play a sound effect
    public void PlaySfx(AudioClip sfx)
    {
        // Stop any other sound effects
        sfxPlayer.Stop();

        // Initialize sound effect
        sfxPlayer.clip = sfx;

        // Play sound effect
        if (isFadingOut == true)
        {
            StopAllCoroutines();
            isFadingOut = false;
        }
        sfxPlayer.volume = 1f;
        sfxPlayer.Play();
    }

    public void FadeOutVol(AudioSource audioSource, float FadeTime)
    {
        isFadingOut = true;
        StartCoroutine(FadeOutRoutine(audioSource, FadeTime));
    }
    public IEnumerator FadeOutRoutine(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
        isFadingOut = false;
    }
}
