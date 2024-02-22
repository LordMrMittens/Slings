using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager
{
    GameObject[] lifeIcons;
    const int maxLives = 5;
    int currentLives;
    public void SetupLives()
    {
        lifeIcons = GameObject.FindGameObjectsWithTag("Life");
        ResetLives();
    }
    public void ResetLives()
    {
        currentLives = maxLives;
        foreach (GameObject life in lifeIcons)
        {
            life.SetActive(true);
        }
    }
    public void LoseLife()
    {
        currentLives--;
        if (IsGameOver())
        {
            Debug.Log("Game Over");
        }
        if(currentLives >= 0)
        {
            lifeIcons[currentLives].SetActive(false);
        }
    }
    public bool IsGameOver()
    {
        return currentLives <= 0;
    }
}
