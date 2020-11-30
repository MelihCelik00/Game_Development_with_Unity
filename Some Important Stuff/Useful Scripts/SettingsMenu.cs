using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    
    public void SetVolume(float volume) // Set volume of general
    {
        audioMixer.SetFloat("volume", volume);
    }
}
