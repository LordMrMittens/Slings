

using UnityEngine.Events;

public class ScoringManager
{
    ScoreDisplayManager scoreDisplayManager;
    public UnityEvent OnScoreThresholdReached = new UnityEvent();
    public int score {get; private set;}
    public int difficultyIncreaseThreshold {get; private set;} = 10;
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
}
