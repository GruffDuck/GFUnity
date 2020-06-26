using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManagr : MonoBehaviour
{
    private int score;
    [SerializeField] private Text text;
    private const string SCORE_KEY = "Score";
    private void Awake()
    {
        score = PlayerPrefs.GetInt(SCORE_KEY);
        UpdateScoreText();
       
    }
    private void UpdateScoreText()
    {
        text.text = score.ToString("N0");
    }
    public void AddScore(int amount)
    {
        score += amount;
        text.text = score.ToString("N0");
        PlayerPrefs.SetInt(SCORE_KEY,score);
        
    }
    
}
