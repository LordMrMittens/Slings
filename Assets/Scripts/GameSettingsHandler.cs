using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsHandler : MonoBehaviour
{
    Slider musicSlider;
    Slider sfxSlider;
    float musicVolume = 0.5f;
    float sfxVolume = 0.5f;

    void SetupSliders()
    {
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        AudioListener.volume = musicVolume;
    }
}
