using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public Button play;
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button backPlayButton;

    public Button options;
    public Button backOptionsButton;
    public Button howToPlay;
    public Button backHowButton;

    public GameObject StartPanel;
    public GameObject MenuButtonPanel;
    public GameObject PlayPanel;
    public GameObject OptionsPanel;
    public GameObject HowPanel;

    void Update()
    {
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount > 0)
        {
            StartPanel.SetActive(false);
            MenuButtonPanel.SetActive(true);
        }
    }

    public void PlayMenu()
    {
        MenuButtonPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }
    public void BackPlay()
    {
        PlayPanel.SetActive(false);
        MenuButtonPanel.SetActive(true);
    }

    public void OptionsMenu()
    {
        MenuButtonPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    public void BackOptions()
    {
        OptionsPanel.SetActive(false);
        MenuButtonPanel.SetActive(true);
    }

    public void HowMenu()
    {
        OptionsPanel.SetActive(false);
        HowPanel.SetActive(true);
    }
    public void BackHow()
    {
        HowPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void level1()
    {
        SceneManager.LoadScene("Level1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
        //Debug.Log("Level Reset");
    }

    public void level2()
    {       
        SceneManager.LoadScene("Level2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        GM.coinTotal = 0;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
