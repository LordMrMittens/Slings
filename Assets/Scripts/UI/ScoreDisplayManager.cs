using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TMP_Text hiScore;
    [SerializeField] TMP_Text playerScore;
    [SerializeField] GameObject newHiScore;
    
    TMP_Text ListOfScoresText;

    void Start()
    {
        UpdateScore(0);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void OnGameOver(int score, bool newHighScore = false){
        playerScore.text = score.ToString();
        if (newHighScore){
            newHiScore.SetActive(true);
        } else {
            newHiScore.SetActive(false);
        }
    }
    void AssignListOfScoresText(){
        ListOfScoresText = GameObject.Find("ListOfScores").GetComponent<TMP_Text>();
    }
    public void UpdateScoresList(int[] scores){
        AssignListOfScoresText();
        string scoresText = "Hi Scores\n\n\n";
        for (int i = 0; i < scores.Length; i++)
        {
            scoresText += i.ToString() + "-" + scores[i].ToString() + "\n";
        }
        ListOfScoresText.text = scoresText;
    }
    

}
