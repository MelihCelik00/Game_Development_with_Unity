using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool PlayerAlive { get; set; }
    public int Stage { get; set; }

    public event Action SceneChanging = delegate { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}