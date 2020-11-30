using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButtonScript : MonoBehaviour
{

    public bool IsPauseButtonClicked = false;
    public GameObject pauseUI1;
    public GameObject pauseUI2;

    /*public void Awake()
    {
        pauseUI1 = GameObject.FindWithTag("englishPause");
        pauseUI2 = GameObject.FindWithTag("turkishPause");
    }*/

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetUIActive();
                FindObjectOfType<PauseMenu>().Pause();
            }
        }
    }

    public void PauseGameButton()
    {
        IsPauseButtonClicked = true;
    }

    public void SetUIActive()
    {
        if (FindObjectOfType<UIManager>().GameLang == 1)
        {
            pauseUI1.SetActive(true);
        }
        else
        {
            pauseUI2.SetActive(true);
        }
    }

}
