﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";
    public AudioSource die;
    public CharControl charScript;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(charScript = null)
        {
            die.Play();
        }

        if (lvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
            //lvlCompStatus = "NotFail";
        }

        if (waittoload > 2)
        {
            SceneManager.LoadScene("Lose1");
            lvlCompStatus = "NotFail";
            CharControl.horizVel = 0;
            CharControl.laneNum = 0;
        }
    }
}
