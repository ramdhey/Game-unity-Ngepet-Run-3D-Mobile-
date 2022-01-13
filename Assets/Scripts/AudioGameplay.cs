using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioGameplay : MonoBehaviour
{
    public Slider bgslider, sfxslider;

    private static readonly string bgPrefs = "bgPrefs";
    private static readonly string sfxPrefs = "sfxPrefs";

    private float bgfloat, sfxfloat;

    public AudioSource bgmusik;

    public AudioSource[] sfxaudio;

    void Awake()
    {
        
        LanjutSetting();


    }
    

    public void LanjutSetting()
    {
        bgfloat = PlayerPrefs.GetFloat(bgPrefs);
        sfxfloat = PlayerPrefs.GetFloat(sfxPrefs);


        bgmusik.volume = bgfloat;

        for (int i = 0; i < sfxaudio.Length; i++)
        {
            sfxaudio[i].volume = sfxfloat; 
        }

    }

    public void UpdateSound()
    {
        bgmusik.volume = bgslider.value;

        for (int i = 0; i < sfxaudio.Length; i++)
        {
            sfxaudio[i].volume = sfxslider.value;
        }

    }


}
