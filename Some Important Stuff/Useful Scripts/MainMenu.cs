using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int IsLanguageEnglish;
    private const string GameLanguage = "Language";

    public GameObject englishMainMenu;
    public GameObject turkishMainMenu;

    [SerializeField] public GameObject duzArkaPlan;
    //[SerializeField] private GameObject videoluArkaPlan;

    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _yuksekSkorMetin;
    private const string LastScore = "Last Score";
    public void Awake()
    {
        IsLanguageEnglish = PlayerPrefs.GetInt(GameLanguage);
    }

    public void Start()
    {
        if (_highScoreText.text != null)
        {
            _highScoreText.text = PlayerPrefs.GetInt(LastScore).ToString("N0");
        }
        if (_yuksekSkorMetin.text != null)
        {
            _yuksekSkorMetin.text = PlayerPrefs.GetInt(LastScore).ToString("N0");
        }
        
        if (IsLanguageEnglish == 1)
        {
            englishMainMenu.SetActive(true);
        }
        else if (IsLanguageEnglish == 0)
        {
            turkishMainMenu.SetActive(true);
        }
    }

    private void Update()
    {
        if (Time.time >= 1.5f && duzArkaPlan != null && duzArkaPlan.GetComponent<Image>().enabled)
        {
            if(duzArkaPlan.GetComponent<Image>() != null)
            {
                duzArkaPlan.GetComponent<Image>().enabled = false;
                Debug.Log("GİRDİİİİİİ");
            }
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
