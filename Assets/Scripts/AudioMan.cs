using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMan : MonoBehaviour
{
    private static readonly string FirstPlay = "firstplay";
    private static readonly string bgPrefs = "bgPrefs";
    private static readonly string sfxPrefs = "sfxPrefs";

    private int firstplayint;

    public Slider bgslider, sfxslider;
    private float bgfloat, sfxfloat;

    
    public AudioSource bgmusik;
    public AudioSource[] sfxaudio;


    void Start()
    {
        firstplayint = PlayerPrefs.GetInt(FirstPlay);

        if (firstplayint == 0)
        {
            bgfloat = .25f;
            sfxfloat = .75f;
            bgslider.value = bgfloat;
            sfxslider.value = sfxfloat;
            PlayerPrefs.SetFloat(bgPrefs, bgfloat);
            PlayerPrefs.SetFloat(sfxPrefs, sfxfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
          bgfloat = PlayerPrefs.GetFloat(bgPrefs);
          sfxfloat = PlayerPrefs.GetFloat(sfxPrefs);
        }
    }

    public void PlaySound(string nama)
    {
        foreach(AudioSource s in sfxaudio)
        {
            if (s.gameObject.tag==gameObject.tag)
                s.Play();
        }
    }

    public void savesound()
    {
        PlayerPrefs.SetFloat(bgPrefs, bgslider.value);
        bgslider.value = bgfloat;
        PlayerPrefs.SetFloat(sfxPrefs, sfxslider.value);
        sfxslider.value = sfxfloat;
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            savesound();

        }
        
    }

    public void UpdateSound()
    {
        bgmusik.volume = bgslider.value;

        for(int i = 0; i < sfxaudio.Length; i++)
        {
            sfxaudio[i].volume = sfxslider.value;
        }

    }



}
