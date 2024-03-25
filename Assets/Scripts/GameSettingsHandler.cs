using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsHandler
{
    Slider musicSlider;
    Slider sfxSlider;

    void SetupSliders()
    {
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();

    }
    public void SetVolumes()
    {
        if (musicSlider == null || sfxSlider == null)
        {
            SetupSliders();
        }
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        AudioHandler.instance.UpdateMusicVolume();
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
    public void LoadVolumes()
    {
        if (musicSlider == null || sfxSlider == null)
        {
            SetupSliders();
        }
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }
    public float GetVolume(string volumeType = "Music")
    {
        if (musicSlider == null || sfxSlider == null)
        {
            SetupSliders();
        }
        return volumeType == "Music" ? musicSlider.value : sfxSlider.value;
    }
}
