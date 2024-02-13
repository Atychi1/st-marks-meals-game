using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject optionsCanvas;
    public GameObject creditsCanvas;

    void Start()
    {
        // Ensure that only the main canvas is initially active
        mainCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionsButtonPressed()
    {
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void OnCreditsButtonPressed()
    {
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void OnBackButtonPressed()
    {
        mainCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }
}
