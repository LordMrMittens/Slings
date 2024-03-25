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
        musicSlider = GameManager.instance.uiControls.MusicSlider;
        sfxSlider = GameManager.instance.uiControls.SfxSlider;

    }
    public void SetVolumes()
    {
        if (musicSlider == null || sfxSlider == null)
        {
            SetupSliders();
        }
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        if (AudioHandler.instance != null){
        AudioHandler.instance.UpdateMusicVolume();}
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
}
