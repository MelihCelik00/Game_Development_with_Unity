using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int IsLanguageEnglish;
    private const string GameLanguage = "Language";

    public GameObject englishMainMenu;
    public GameObject turkishMainMenu;

    public void Awake()
    {
        IsLanguageEnglish = PlayerPrefs.GetInt(GameLanguage);
    }

    public void Start()
    {
        
        if (IsLanguageEnglish == 1)
        {
            englishMainMenu.SetActive(true);
        }
        else if (IsLanguageEnglish == 0)
        {
            turkishMainMenu.SetActive(true);
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        IsLanguageEnglish = 0;
        PlayerPrefs.SetInt(GameLanguage,IsLanguageEnglish);
    }

    public void PlayGameEnglish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        IsLanguageEnglish = 1;
        PlayerPrefs.SetInt(GameLanguage,IsLanguageEnglish);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetLanguageToTurkish()
    {
        IsLanguageEnglish = 0;
        PlayerPrefs.SetInt(GameLanguage,IsLanguageEnglish);
        PlayerPrefs.Save();
    }

    public void SetLanguageToEnglish()
    {
        IsLanguageEnglish = 1;
        PlayerPrefs.SetInt(GameLanguage,IsLanguageEnglish);
        PlayerPrefs.Save();
    }
}
