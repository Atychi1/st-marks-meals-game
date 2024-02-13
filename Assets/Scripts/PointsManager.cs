using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public int points = 0;
    public int highestScore = 0;
    public TMP_Text scoreText; // Reference to the TMP Text component for current score
    public TMP_Text finalScoreText; // Reference to the TMP Text component for final score display
    public TMP_Text highScoreText; // Reference to the TMP Text component for high score display

    void Start()
    {
        // Retrieve the highest score from PlayerPrefs when the game starts
        if (PlayerPrefs.HasKey("HighestScore"))
        {
            highestScore = PlayerPrefs.GetInt("HighestScore");
        }
        UpdateHighScore(); // Update high score text when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        // Update the TMP Text with the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + points.ToString();
        }
        UpdateHighestScore();
        UpdateHighScore();
        UpdateFinalScore();
        
        if (Input.GetKey(KeyCode.P))
        {
            ResetHighestScore();
        }
    }

    // Call this method to update the final score text
    public void UpdateFinalScore()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = "Score: " + points.ToString();
        }
    }

    // Call this method to update the highest score text
    public void UpdateHighScore()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "Your Highest Score: " + highestScore.ToString();
        }
    }

    // Call this method to update the highest score
    public void UpdateHighestScore()
    {
        if (points > highestScore)
        {
            highestScore = points;
            // Save the highest score using PlayerPrefs
            PlayerPrefs.SetInt("HighestScore", highestScore);
            PlayerPrefs.Save(); // Make sure to call Save() after setting PlayerPrefs
        }
    }

    // Call this method to reset the highest score for testing purposes
    public void ResetHighestScore()
    {
        highestScore = 0;
        PlayerPrefs.DeleteKey("HighestScore");
    }
}

