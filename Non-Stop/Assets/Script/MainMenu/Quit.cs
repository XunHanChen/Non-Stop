using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    /// <summary>
    /// A function to quit the application.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void PauseGame(){
        Time.timescale=0;
    }
}
