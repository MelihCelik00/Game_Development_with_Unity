using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score;
    private const string keyString = "Score";

    public int comboCounter = 0;
    public int Score { get => _score; }
    public int point = 5;
    
    public void UpdateScoreText(int _scoreT)
    {
        _scoreText.text = _scoreT.ToString("N0");
    }
    
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreText(_score);
        PlayerPrefs.SetInt(keyString, _score);
    }
}