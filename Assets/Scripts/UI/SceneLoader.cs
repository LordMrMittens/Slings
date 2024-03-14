using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake() {
        SceneManager.sceneLoaded += OnSceneHasLoaded;
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    void OnSceneHasLoaded(Scene scene, LoadSceneMode mode)
    {
        GameManager.instance.ResetGameManager(scene.buildIndex);
    }
}
