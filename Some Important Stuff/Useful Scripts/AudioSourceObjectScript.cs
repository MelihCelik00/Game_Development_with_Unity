using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceObjectScript : MonoBehaviour
{
    private void Update()
    {

        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }
}
