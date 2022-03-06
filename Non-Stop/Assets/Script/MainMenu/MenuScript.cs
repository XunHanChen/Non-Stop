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

    public GameObject StartPanel;
    public GameObject MenuButtonPanel;
    public GameObject PlayPanel;
    public GameObject OptionsPanel;

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

    public void level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void level2()
    {       
        SceneManager.LoadScene("Level2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
    }
}
