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
        SavedVolume = PlayerPrefs.GetFloat("Volume");
        if (SavedVolume != null)
        {
            turkceSlider.value = SavedVolume;
            englishSlider.value = SavedVolume;
        }   

    }
}
