using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  Vector3 screenBounds {get; private set;}
    public ScoringManager scoringManager;
    void Start()
    {
        instance = this;
        scoringManager = new ScoringManager();
        scoringManager.SetScoreDisplayManager(FindObjectOfType<ScoreDisplayManager>());
        screenBounds = Camera.main.ScreenToWorldPoint(Vector2.zero);//move this to a controller class
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
