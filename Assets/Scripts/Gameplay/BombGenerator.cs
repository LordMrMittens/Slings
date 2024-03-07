using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] GameObject BombPrefab;
    
    //Move this to a controller class
    // Start is called before the first frame update
    Vector2 bombCreationBounds;
    public float creationFrequency{get; private set;} = 1;
    float timeOfLastBomb;
    void Start()
    {
        bombCreationBounds = GameManager.instance.screenBounds;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Time.time - timeOfLastBomb > creationFrequency)
        {
        float randomX = UnityEngine.Random.Range(bombCreationBounds.x+0.5f, MathF.Abs(bombCreationBounds.x) -0.5f);
        Vector2 spawnPoint = new Vector2(randomX, MathF.Abs(bombCreationBounds.y-1)); //add offset so bombs are created off screen
        GameObject fallingBomb = Instantiate(BombPrefab, spawnPoint, Quaternion.identity);
        Bomb bomb = fallingBomb.GetComponentInChildren<Bomb>();
        bomb.OnDisable.AddListener(GameManager.instance.scoringManager.AddScore);
        bomb.OnExplode.AddListener(GameManager.instance.livesManager.LoseLife);
        timeOfLastBomb = Time.time; 
        }

        //create bombs
        //increase speed of bombs with time? possibly done in a separate class
    }
    public void SetCreationFrequency(float frequency)
    {
        creationFrequency = frequency;
    }
}
