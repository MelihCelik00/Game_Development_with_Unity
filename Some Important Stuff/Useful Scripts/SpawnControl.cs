using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public bool isObjectSpawned;

    private GameObject _lastSpawn;

    public GameObject lastSpawn
    {
        set { _lastSpawn = value; }
        get { return _lastSpawn; }
    }
    
    private GameObject[] nucleos;
    
    private void Start()
    {
        nucleos = new GameObject[] { };
    }
    
    
}
