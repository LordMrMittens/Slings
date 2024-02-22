using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager
{
    public GameObject[] lifeIcons {get; private set;}
    const int maxLives = 4;
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
    public void LoseLife(GameObject lifeIcon)
    {
        currentLives--;
        if (IsGameOver())
        {
            Debug.Log("Game Over");
        }
        if(currentLives >= 0)
        {
            lifeIcon.SetActive(false);
        }
    }
    public bool IsGameOver()
    {
        return currentLives <= 0;
    }
    public List<GameObject> GetActiveLifeIconTransforms(){
        List<GameObject> icons = new List<GameObject>();
        foreach (GameObject life in lifeIcons)
        {
            if (life.activeSelf){
            icons.Add(life);}
        }
        return icons;
    }
}
