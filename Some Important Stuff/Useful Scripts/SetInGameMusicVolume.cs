using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInGameMusicVolume : MonoBehaviour
{
    private float musicVolume = 0;
    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("Volume");
        this.gameObject.GetComponent<AudioSource>().volume = musicVolume;
    }
}
