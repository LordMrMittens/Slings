using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData
{
    public string name;
    public AudioClip audioClip;
}

public class AudioLibrary : MonoBehaviour
{
    public AudioData[] SFXCollection;
    public AudioData[] musicCollection;
    public Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();
    private void Awake()
    {
        AddClipsToCollection(SFXCollection);
        AddClipsToCollection(musicCollection);
    }

    private void AddClipsToCollection(AudioData[] audioCollection)
    {
        foreach (AudioData data in audioCollection)
        {
            audioDictionary.Add(data.name, data.audioClip);
        }
    }

    public AudioClip GetAudioClip(string clipName)
    {
        if(audioDictionary.ContainsKey(clipName))
        {
            return audioDictionary[clipName];
        }
        else
        {
            Debug.LogError("Audio clip not found");
            return null;
        }
    }
}
