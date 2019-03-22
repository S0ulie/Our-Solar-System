using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioMusic;
    public AudioClip audioClickPlanet;
    public AudioClip audioGoBack;
    public AudioClip audioTravel;
    public AudioClip audioSwitchMode;
    AudioSource musicPlayer;
    AudioSource sfxPlayer;
    AudioSource myAudioSource3;

    // Initialize Audio Controller
    void Start()
    {
        musicPlayer = AddAudio(true, false, 0.2f);
        sfxPlayer = AddAudio(false, false, 0.3f);

        // Start Music
        musicPlayer.clip = audioMusic;
        musicPlayer.Play();
    }

    // Create an Audio Source
    public AudioSource AddAudio(bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>(); 
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }
    /*
    public void PlaySfx()
    {

    }
    */
}
