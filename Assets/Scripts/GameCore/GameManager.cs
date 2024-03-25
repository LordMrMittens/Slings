using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class GameManager : Singleton<GameManager>
{
    [SerializeField] int difficultyIncreaseThreshold = 20;
    [SerializeField] float difficultyIncreaseThresholdIncreasePercent = 1.1f;
    public  Vector3 screenBounds {get; private set;}
    public ScoringManager scoringManager;
    public LivesManager livesManager;
    public UIControls uiControls {get; private set;}
    DifficultyHandler difficultyHandler;
    public PowerUpHandler powerUpHandler {get; private set;}
    public GameSettingsHandler gameSettingsHandler {get; private set;}
    
    [SerializeField] GameObject lifeExplosionPrefab;
    public bool isPaused {get; private set;} = false;

    //handle application lost focus on mobile
    void Start()
    {
        ResetGameManager(0);
        //move this to a controller class
    }
    public void ResetGameManager(int sceneIndex){
         (sceneIndex == 0 ? (System.Action)MainMenuReset : GameSceneReset)();
    }
    public void MainMenuReset()
    {
        scoringManager = new ScoringManager();
        gameSettingsHandler = new GameSettingsHandler();
        gameSettingsHandler.LoadVolumes();
        scoringManager.SetScoreDisplayManager(FindObjectOfType<ScoreDisplayManager>());
        livesManager = null;
        difficultyHandler = null;
        powerUpHandler = null;
        uiControls = null;
    }
    public void GameSceneReset() {
        screenBounds = Camera.main.ScreenToWorldPoint(Vector2.zero);
        livesManager = new LivesManager();
        livesManager.SetupLives(lifeExplosionPrefab);
        livesManager.OnGameOver.AddListener(GameOverLogic);
        if(scoringManager == null)
        {
            scoringManager = new ScoringManager();
        }
        scoringManager.SetScoreDisplayManager(FindObjectOfType<ScoreDisplayManager>(), difficultyIncreaseThreshold, difficultyIncreaseThresholdIncreasePercent);
        difficultyHandler = new DifficultyHandler();
        difficultyHandler.SetDifficultyHandler(FindObjectOfType<BombGenerator>(), scoringManager);
        powerUpHandler = FindObjectOfType<PowerUpHandler>();
        uiControls = FindObjectOfType<UIControls>();
        isPaused = false;
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void ToggleTimeStop()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isPaused = Time.timeScale == 0;
    }
    void GameOverLogic()
    {
        ToggleTimeStop();
        uiControls.ActivateGameOverMenu(scoringManager.score);
        scoringManager.OnGameOver();
    }
    public static void MoveAndroidApplicationToBack()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

}
