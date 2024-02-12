using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public int points = 0;
    public TMP_Text scoreText; // Reference to the TMP Text component

    // Update is called once per frame
    void Update()
    {
        // Update the TMP Text with the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + points.ToString();
        }
    }
}