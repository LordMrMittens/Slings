using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesManager
{
    public GameObject[] lifeIcons {get; private set;}
    const int maxLives = 4;
    int currentLives;
    GameObject[] lifePositions = new GameObject[maxLives];
    GameObject lifeExplosionPrefab;
    public UnityEvent OnGameOver = new UnityEvent();
    public void SetupLives(GameObject lifeExplosionPrefabs)
    {
        lifeIcons = GameObject.FindGameObjectsWithTag("Life");
        lifeExplosionPrefab = lifeExplosionPrefabs;
        SpaceOutLives();
        
    }
    public void ResetLives()
    {
        currentLives = maxLives;
        int positionIndex = 0;
        foreach (GameObject life in lifeIcons)
        {
            life.SetActive(true);
            life.transform.position = lifePositions[positionIndex].transform.position;
            positionIndex++; 
        }
    }
    public void SpaceOutLives()
    {
        float lifeSpacing = (GameManager.instance.screenBounds.x * 2) / maxLives+.3f;
        float offset = 0;
        for (int i = 0; i < maxLives; i++)
        {
            lifePositions[i] = new GameObject("LifePosition" + i);
            if (i > 1)
            {
                offset = lifeSpacing;
            }
            lifePositions[i].transform.position = new Vector3(((lifeSpacing*i)+offset)-(lifeSpacing*2), lifeIcons[i].transform.position.y, 0);
        }
        ResetLives();
    }
    public void LoseLife(GameObject lifeIcon)
    {
        currentLives--;
        if (IsGameOver())
        {
            Debug.Log("Game Over");
            OnGameOver.Invoke();
        }
        if(currentLives >= 0)
        {
            GameObject.Instantiate(lifeExplosionPrefab, lifeIcon.transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
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
