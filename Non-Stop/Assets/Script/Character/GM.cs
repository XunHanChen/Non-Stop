using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";
    public AudioSource dieSource;
    public AudioClip dieClip;
    //private float Volume = 0.1f;

    public Slider dieSlider;
    private float dieVolume;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        CharControl.character = Player;

        dieVolume = PlayerPrefs.GetFloat("SoundVol");
        dieSource.volume = dieVolume;
        dieSlider.value = dieVolume;
    }

    // Update is called once per frame
    void Update()
    {
        dieSource.volume = dieVolume;
        PlayerPrefs.SetFloat("SoundVol", dieVolume);

        if (!Player.active)
        {
            Debug.Log("Die");
            dieSource.PlayOneShot(dieClip, dieVolume);
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

    public void DieSoundUpdater(float vol)
    {
        dieVolume = vol;
    }
}
