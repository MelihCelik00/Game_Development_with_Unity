using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private const string GameLanguage = "Language";
    public int GameLang;
    
    private void Awake()
    {
        GameLang = PlayerPrefs.GetInt(GameLanguage);
    }
    
}

