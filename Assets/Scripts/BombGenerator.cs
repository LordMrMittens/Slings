using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] GameObject TestObject;
    Vector3 screenBounds;//Move this to a controller class
    // Start is called before the first frame update
    Vector2 bombCreationBounds;
    float creationFrequency;
    float timeOfLastBomb;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(Vector2.zero);//move this to a controller class
        bombCreationBounds = screenBounds;
        //find bounds of screen
        //set bounds for bomb creation
    }

    // Update is called once per frame
    void Update()
    { 
        float randomX = UnityEngine.Random.Range(bombCreationBounds.x, MathF.Abs(bombCreationBounds.x));
        Vector2 spawnPoint = new Vector2(randomX, MathF.Abs(bombCreationBounds.y)); //add offset so bombs are created off screen
        Instantiate(TestObject, spawnPoint, Quaternion.identity);
        timeOfLastBomb = Time.time;
        //create bombs
        //increase speed of bombs with time? possibly done in a separate class
    }
}
