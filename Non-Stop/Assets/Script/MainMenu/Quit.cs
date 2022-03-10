using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    /// <summary>
    /// Load level 1
    /// </summary>
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// A function to quit the application.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void PauseGame(){
        Time.timeScale=0;
    }
}
