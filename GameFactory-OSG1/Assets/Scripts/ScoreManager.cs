using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private Text _scoreText;
        
    private int _score;

    public void AddScore(int amount)
    {
        _score += amount;

        _scoreText.text = _score.ToString();
    }
}
