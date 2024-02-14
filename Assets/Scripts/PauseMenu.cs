using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject gameCanvas;
    public GameObject deadCanvas;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseCanvas.SetActive(true); // Enable the pause canvas
        gameCanvas.SetActive(false); // Disable the game canvas
        deadCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pauseCanvas.SetActive(false); // Disable the pause canvas
        gameCanvas.SetActive(true); // Enable the game canvas
        deadCanvas.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Resume the game if paused
        SceneManager.LoadScene("MenuScene"); // Load the menu scene
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game if paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        deadCanvas.SetActive(false);
    }

    public void GameOver()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseCanvas.SetActive(false); // Enable the pause canvas
        gameCanvas.SetActive(false); // Disable the game canvas
        deadCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Play("GameOver");
        FindObjectOfType<AudioManager>().Stop("MainTheme");
    }
}