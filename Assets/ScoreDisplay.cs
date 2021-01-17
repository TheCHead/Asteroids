using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] Text scoreText = null;
    int score = 0;

    private void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddToScore(int score)
    {
        this.score += score;
        UpdateScoreDisplay();
        
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
