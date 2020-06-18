using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private Text _scoreText;
        
    private int _score;

    private void Awake()
    {
        _score = PlayerPrefs.GetInt("Score");
        _scoreText.text = _score.ToString("N0");
    }


    public void AddScore(int amount)
    {
        _score += amount;

        _scoreText.text = _score.ToString();
        
        PlayerPrefs.SetInt("Score",_score);
    }
}
