using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource _AudioSource;
    public AudioClip _matchAudio;
    
    private float volume;
    private float volumeCoefficient;
    private GameObject gameObject;
    public float Volume
    {
        get => volume;
    }

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        GameObject.FindGameObjectWithTag("InGameAudioManager").GetComponent<AudioSource>().volume = volume;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume=volume;
    }
}
