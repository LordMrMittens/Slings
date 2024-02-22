

public class ScoringManager
{
    ScoreDisplayManager scoreDisplayManager;
    int score;
    public void SetScoreDisplayManager(ScoreDisplayManager scoreDisplayManager)
    {
        this.scoreDisplayManager = scoreDisplayManager;
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        
        UpdateScoreDisplay();
    }
    void UpdateScoreDisplay()
    {
        scoreDisplayManager.UpdateScore(score);
    }
}
