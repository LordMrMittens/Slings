

using UnityEngine;
using UnityEngine.Events;

public class ScoringManager
{
    ScoreDisplayManager scoreDisplayManager;
    public UnityEvent OnScoreThresholdReached = new UnityEvent();
    public int score {get; private set;}
    public int difficultyIncreaseThreshold {get; private set;}
    public float difficultyIncreaseThresholdIncreasePercent {get; private set;}
    int currentDifficultuBuildup;
    const int scoreListSize = 15;
    public void SetScoreDisplayManager(ScoreDisplayManager scoreDisplayManager, int difficultyIncreaseThreshold = 0, float difficultyIncreaseThresholdIncreasePercent =0)
    {
        this.scoreDisplayManager = scoreDisplayManager;
        this.difficultyIncreaseThreshold = difficultyIncreaseThreshold;
        this.difficultyIncreaseThresholdIncreasePercent = difficultyIncreaseThresholdIncreasePercent;
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        currentDifficultuBuildup += scoreToAdd;
        UpdateScoreDisplay();
        CheckScoreThreshold();
    }
    void UpdateScoreDisplay()
    {
        scoreDisplayManager.UpdateScore(score);
    }
    void CheckScoreThreshold()
    {
        if(currentDifficultuBuildup > difficultyIncreaseThreshold)
        {
            currentDifficultuBuildup = 0;
            difficultyIncreaseThreshold = (int)(difficultyIncreaseThreshold * difficultyIncreaseThresholdIncreasePercent); 
            OnScoreThresholdReached.Invoke();
        }
    }
    public void OnGameOver()
    {
        scoreDisplayManager.OnGameOver(score,PlayerPrefs.GetInt("score0") ,IsHighScore());
        UpdateScores();
    }
    public void ResetScoresList(){
        for (int i = 0; i < scoreListSize; i++)
        {
            PlayerPrefs.SetInt("score" + i, 0);
        }
        SetScoreList();
    }
    public int[] GetScores()
    {
        int[] scores = new int[scoreListSize];
        UpdateScores();
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

