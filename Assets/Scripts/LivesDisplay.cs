using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int startLives = 3;
    [SerializeField] Text livesText = null;
    int currentLives = 0;
    [SerializeField] Canvas gameOverCanvas = null;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentLives = startLives;
        UpdateLivesDisplay();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void UpdateLivesDisplay()
    {
        livesText.text = "X " + currentLives.ToString();
    }

    public void TakeLife()
    {
        currentLives--;
        if (currentLives < 0)
        {
            currentLives = 0;
            UpdateLivesDisplay();
            DeathSequence();
        }
        
        UpdateLivesDisplay();
    }

    private void DeathSequence()
    {
        Time.timeScale = 0f;
        gameOverCanvas.gameObject.SetActive(true);
    }
}
