using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private Text _scoreText;
    
    private int _score;
    
    private const string SCORE_KEY = "Score";

    private void Awake()
    {
        //Skoru kaydeder.  **PlayerPrefs**
        _score = PlayerPrefs.GetInt(SCORE_KEY);
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
        
        PlayerPrefs.SetInt(SCORE_KEY, _score);
    }
    }
