using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;
    [SerializeField] AudioLibrary audioLibrary;
    AudioSource musicSource;
    AudioClip currentMusic;
    private void Start() {
        instance = this;
        musicSource = gameObject.AddComponent<AudioSource>();
        UpdateMusicVolume();
    }
    public void UpdateMusicVolume()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
    public void PlayAudioEffect(String clipName)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        audioSource.clip = audioLibrary.GetAudioClip(clipName);
        audioSource.Play();
        Destroy(audioSource, audioSource.clip.length);
    }
    public void PlayMusic(String clipName) //what is the difference between this and the above method?
    {
        musicSource.clip = audioLibrary.GetAudioClip(clipName);
        currentMusic = musicSource.clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
        musicSource.clip = null;
    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }
    public void PlayMusicOnce(String clipName)
    {
        musicSource.clip = audioLibrary.GetAudioClip(clipName);
        currentMusic = musicSource.clip;
        musicSource.loop = false;
        musicSource.Play();
    }
}
