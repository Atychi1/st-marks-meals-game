using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstTimeSetup : MonoBehaviour
{
    public const string FirstTimeKey = "FirstTime_MainScene_Loaded";
    

    public GameObject howToPlay1;
    public GameObject howToPlay2;
    public GameObject howToPlay3;

    void Start()
    {
        if (!PlayerPrefs.HasKey(FirstTimeKey))
        {
            ActivateCanvases();
            PlayerPrefs.SetInt(FirstTimeKey, 1);
        }
        if (!PlayerPrefs.HasKey("FirstTime_MainScene_Loaded"))
        {
            // Perform first-time setup
            FirstTimeSetup1();
        }
    }


    void FirstTimeSetup1()
    {
        PlayerPrefs.SetInt("FirstTime_MainScene_Loaded", 1);
    }
    public void ActivateCanvases()
    {
        Time.timeScale = 0f;
        howToPlay1.SetActive(true);
        howToPlay2.SetActive(false);
        howToPlay3.SetActive(false);
    }

    public void NextTutorial1()
    {
        howToPlay1.SetActive(false);
        howToPlay2.SetActive(true);
        howToPlay3.SetActive(false);
    }

   public void NextTutorial2()
    {
        howToPlay1.SetActive(false);
        howToPlay2.SetActive(false);
        howToPlay3.SetActive(true);
    }

    public void Close()
    {
        Time.timeScale = 1f;
        howToPlay1.SetActive(false);
        howToPlay2.SetActive(false);
        howToPlay3.SetActive(false);
    }
}
