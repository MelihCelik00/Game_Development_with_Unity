using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public PauseGameButtonScript pauseButton;

    public GameObject pauseMenuUI1 = null;
    public GameObject pauseMenuUI2 = null;
    public GameObject loseMenuTurkce;
    public GameObject loseMenuEnglish;

    bool isPaused = false;
    private int GetLang;
    private const string GameLanguage = "Language";
    private const string LastScore = "Last Score";
    
    public int life = 3;
    void Update()
    {
        GetLang = PlayerPrefs.GetInt(GameLanguage);
        if (life==0) // Lose round here and set lose menu active
        {
            PlayerPrefs.SetInt(LastScore, FindObjectOfType<ScoreManager>().Score); // To find high score!
            if (GetLang==1)
            {
                loseMenuEnglish.SetActive(true);
                Pause();
            }
            else if (GetLang == 0)
            {
                loseMenuTurkce.SetActive(true);
                Pause();
            }
        }
        CloseExtraMenusWhenLost();
        if (isPaused) // If player exits from game but not close it, PAUSE the game
        {
            //GetLang = PlayerPrefs.GetInt(GameLanguage);
            if (GetLang==1)
            {
                pauseMenuUI1.SetActive(true);
                Pause();
            }
            else if (GetLang == 0)
            {
                pauseMenuUI2.SetActive(true);
                Pause();
            }
        }
        
        
        // Detect if player clicked to pause button
        if (pauseMenuUI1.active) // Game paused now
        {
            Pause();
        }
        else if (pauseMenuUI2.active)
        {
            Pause();
        }
    }

    public void RestartNewGame() // Restart without watching ads
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    public void Pause() {Time.timeScale = 0f;}

    public void Resume()
    {
        Time.timeScale = 1f;
        //pauseButton.IsPauseButtonClicked = false;
        CheckActiveMenuAndDeactivate();
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void CheckActiveMenuAndDeactivate()
    {
        if (pauseMenuUI1.active) // Game paused now
        {
            pauseMenuUI1.SetActive(false);
        }
        else if (pauseMenuUI2.active)
        {
            pauseMenuUI2.SetActive(false);
        }
        else if (loseMenuEnglish.active)
        {
            loseMenuEnglish.SetActive(false);
        }
        else if(loseMenuTurkce.active)
        {
            loseMenuTurkce.SetActive(false);
        }
    }
    
    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }

    private void CloseExtraMenusWhenLost()
    {
        if (loseMenuEnglish.active || loseMenuTurkce.active) // Game paused now
        {
            if (GetLang==1)
            {
                pauseMenuUI1.SetActive(false);
            }
            else if (GetLang == 0)
            {
                pauseMenuUI2.SetActive(false);
            }
        }
    }
    
}