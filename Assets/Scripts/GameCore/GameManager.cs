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
    void Start()
    {
        instance = this;
        screenBounds = Camera.main.ScreenToWorldPoint(Vector2.zero);
        livesManager = new LivesManager();
        livesManager.SetupLives(lifeExplosionPrefab);
        scoringManager = new ScoringManager();
        scoringManager.SetScoreDisplayManager(FindObjectOfType<ScoreDisplayManager>());
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        //move this to a controller class
    }
    public void TogglePause()
    {
        Debug.Log("Pause");
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
