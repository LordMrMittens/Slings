using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler
{
    BombGenerator bombGenerator;
    ScoringManager scoringManager;

    public void SetDifficultyHandler(BombGenerator bombGenerator, ScoringManager scoringManager)
    {
        this.bombGenerator = bombGenerator;
        this.scoringManager = scoringManager;
        scoringManager.OnScoreThresholdReached.AddListener(IncreaseDifficulty);
    }
    void IncreaseDifficulty()
    {
        bombGenerator.SetCreationFrequency(bombGenerator.creationFrequency * 0.97f);
    }
}
