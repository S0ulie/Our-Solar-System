using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // DECLARE
    // Create a singleton for easy access
    public static AudioController Instance;

    // Music
    public AudioClip audioMusic;

    // Sfx
    static public AudioClip audioClickPlanet;
    static public AudioClip audioGoBack;
    static public AudioClip audioTravel;
    static public AudioClip audioSwitchMode;

    // Audio players
    AudioSource musicPlayer;
    AudioSource sfxPlayer;

    // Initialize Singleton and audio clips
    void Awake()
    {
        #region Singleton

        Instance = this;

        #endregion

        audioClickPlanet = Resources.Load("SFX/Buttons/Button_4_pack2") as AudioClip;
        audioGoBack = Resources.Load("SFX/Buttons/Button_8_pack2") as AudioClip;
        audioTravel = Resources.Load("SFX/Appear") as AudioClip;
        audioSwitchMode = Resources.Load("SFX/Buttons/Button_22_pack2") as AudioClip;
    }

    // Initialize audio players
    void Start()
    {
        musicPlayer = AddAudio(true, false, 1.0f);
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
        // Pause music
        musicPlayer.Pause();

        // Initialize sound effect
        sfxPlayer.clip = sfx;

        // Start sfx coroutine
        StartCoroutine(SfxRoutine());
    }
    IEnumerator SfxRoutine()
    {
        // Play sound effect
        sfxPlayer.Play();
        yield return new WaitWhile(() => sfxPlayer.isPlaying);

        // Once sound effect has finished, fade in music
        float increment = 0.1f;
        for (float vol = 0f; vol <= 1; vol += increment)
        {
            musicPlayer.volume = vol;
            yield return new WaitForSeconds(increment);
        }
    }
}
