using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    //Bgm
    public AudioSource BgmSource;
    public Slider BgmSlider;
    private float BgmVolume = 1f;

    //Sound
    public AudioSource SoundSource;
    public Slider SoundSlider;
    private float SoundVolume = 1f;

    //Sound.Player
    public AudioSource coins, jump;

    //public CharControl CharC;

    // Start is called before the first frame update
    void Start()
    {
        //Bgm
        BgmSource.Play();
        BgmVolume = PlayerPrefs.GetFloat("BgmVol");
        BgmSource.volume = BgmVolume;
        BgmSlider.value = BgmVolume;

        //Sound
        SoundVolume = PlayerPrefs.GetFloat("SoundVol");
        SoundSource.volume = SoundVolume;
        coins.volume = SoundVolume;
        jump.volume = SoundVolume;
        //die.volume = SoundVolume;
        SoundSlider.value = SoundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        //Bgm
        BgmSource.volume = BgmVolume;
        PlayerPrefs.SetFloat("BgmVol", BgmVolume);

        //Sound
        SoundSource.volume = SoundVolume;
        coins.volume = SoundVolume;
        jump.volume = SoundVolume;
        //die.volume = SoundVolume;
        PlayerPrefs.SetFloat("SoundVol", SoundVolume);

        if (CharControl.jumpInput == 0)
        {
            jump.Play();
        }

        //if (CharControl.dead == 1)
        //{
        //    die.Play();
        //    Debug.Log("Die");
        //}
    }

    public void BgmUpdater(float volume)
    {
        BgmVolume = volume;
    }

    public void SoundUpdater(float volume)
    {
        SoundVolume = volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Obstacle")
        //{
        //    Debug.Log("Trigger");
        //}

        if (other.gameObject.tag == "Coin")
        {
            coins.Play();
        }
    }
}
