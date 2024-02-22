using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScore(0);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
