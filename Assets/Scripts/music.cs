using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public static music Instance { get; set; }

    public Slider slidervolume;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("musik"))
        {
            PlayerPrefs.SetFloat("musik", 1);
            Load();
        }

    }

   public void ubahvolume()
    {
        AudioListener.volume = slidervolume.value;
        save();
    }

    private void Load()
    {
        slidervolume.value = PlayerPrefs.GetFloat("musik");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musik", slidervolume.value);
    }

}
