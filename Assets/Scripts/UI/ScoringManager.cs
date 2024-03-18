

using UnityEngine;
using UnityEngine.Events;

public class ScoringManager
{
    ScoreDisplayManager scoreDisplayManager;
    public UnityEvent OnScoreThresholdReached = new UnityEvent();
    public int score {get; private set;}
    public int difficultyIncreaseThreshold {get; private set;} = 10;
    [SerializeField] int scoreListSize = 5;
    public void SetScoreDisplayManager(ScoreDisplayManager scoreDisplayManager, int difficultyIncreaseThreshold = 10)
    {
        this.scoreDisplayManager = scoreDisplayManager;
        this.difficultyIncreaseThreshold = difficultyIncreaseThreshold;
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreDisplay();
        CheckScoreThreshold();
    }
    void UpdateScoreDisplay()
    {
        scoreDisplayManager.UpdateScore(score);
    }
    void CheckScoreThreshold()
    {
        if(score % difficultyIncreaseThreshold == 0)
        {
            OnScoreThresholdReached.Invoke();
        }
    }
    public void OnGameOver()
    {
        scoreDisplayManager.OnGameOver(score, IsHighScore());
        UpdateScores();
    }
    public void ResetScoresList(){
        for (int i = 0; i < scoreListSize; i++)
        {
            PlayerPrefs.SetInt("score" + i, 0);
        }
    }
    public int[] GetScores()
    {
        int[] scores = new int[scoreListSize];
        for (int i = 0; i < scoreListSize; i++)
        {
            scores[i] = PlayerPrefs.GetInt("score" + i);
        }
        return scores;
    }
    public void SetScoreList(){
        scoreDisplayManager.UpdateScoresList(GetScores());
    }
    void UpdateScores()
    {
        for (int i = 0; i < scoreListSize; i++)
        {
            if (PlayerPrefs.HasKey("score" + i))
            {
                if (score > PlayerPrefs.GetInt("score" + i))
                {
                    int tempScore = PlayerPrefs.GetInt("score" + i);
                    PlayerPrefs.SetInt("score" + i, score);
                    score = tempScore;
                }
            }
            else
            {
                PlayerPrefs.SetInt("score" + i, score);
                score = 0;
            }
        }
        PlayerPrefs.Save();
    }
    public bool IsHighScore()
    {
        return score > PlayerPrefs.GetInt("score0");
    }
}

