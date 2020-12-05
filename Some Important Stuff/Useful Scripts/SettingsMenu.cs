using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private const string volumeKeyString = "Volume";
    public AudioMixer audioMixer;
    
    [SerializeField] public Slider turkceSlider;
    [SerializeField] public Slider englishSlider;

    private const string firstLogin = "FirstLogin";
    
    private float SavedVolume;
    private void Start()
    {
        SetSlidersOnStartup();
    }

    public void SetVolume(float volume) // Set volume of general
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat(volumeKeyString,volume);
    }

    private void SetSlidersOnStartup()
    {
        SavedVolume = PlayerPrefs.GetFloat(volumeKeyString,1);
        Debug.Log(SavedVolume);
        if (PlayerPrefs.GetInt(firstLogin, 1) == 1)
        {
            audioMixer.SetFloat("volume", 1);
            PlayerPrefs.SetFloat(volumeKeyString,1);
            PlayerPrefs.SetInt(firstLogin, 0); //Set first time opening to false
        }
        else
        {
            audioMixer.SetFloat("volume", SavedVolume);
            turkceSlider.value = SavedVolume;
            englishSlider.value = SavedVolume;
        }
        Debug.Log(PlayerPrefs.GetFloat("Volume"));
    }
}