using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + GM.coinTotal;

        //if (gameObject.name == "coinstxt")
        //{
        //    //GetComponent<TextMesh>().text = "Total coins: " + GM.coinTotal;
        //}

        //if (gameObject.name == "timetxt")
        //{
        //    GetComponent<TextMesh>().text = "Time: " + GM.coinTotal;
        //}
    }
}
