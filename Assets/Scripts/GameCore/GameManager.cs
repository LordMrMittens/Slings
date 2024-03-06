using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  Vector3 screenBounds {get; private set;}
    public ScoringManager scoringManager;
    public LivesManager livesManager;
    [SerializeField] GameObject lifeExplosionPrefab;
    public bool isPaused {get; private set;} = false;
    void Start()
    {
        instance = this;
        Reset();
        //move this to a controller class
    }
    public void Reset() {
        screenBounds = Camera.main.ScreenToWorldPoint(Vector2.zero);
        livesManager = new LivesManager();
        livesManager.SetupLives(lifeExplosionPrefab);
        scoringManager = new ScoringManager();
        scoringManager.SetScoreDisplayManager(FindObjectOfType<ScoreDisplayManager>());
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isPaused = Time.timeScale == 0;
    }
}
