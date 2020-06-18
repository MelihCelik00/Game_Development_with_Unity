using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private Text _scoreText;
        
    private int _score;
    private const string keyString = "Score";

    private void Awake()
    {
        _score = PlayerPrefs.GetInt(keyString);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString("N0");
    }


    public void AddScore(int amount)
    {
        _score += amount;

        UpdateScoreText();
        
        PlayerPrefs.SetInt(keyString, _score);
    }
}
