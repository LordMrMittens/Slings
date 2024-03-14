using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    [field : SerializeField] public GameObject pauseMenu;
    [field : SerializeField] public GameObject gameOverMenu;
    [SerializeField] TMP_Text hiScore;
    [SerializeField] TMP_Text playerScore;
    [SerializeField] GameObject newHiScore;

    public void TogglePause()
    {
        GameManager.instance.ToggleTimeStop();
    }
    public void ActivateGameOverMenu(int score)
    {
        gameOverMenu.SetActive(true);
        playerScore.text = score.ToString();

        //get hi score
        //if new hi score, update and display message
        newHiScore.SetActive(true);
    }
    public void DeactivateGameOverMenu()
    {
        newHiScore.SetActive(false);
        gameOverMenu.SetActive(false);
    }
    public void ForceFocusPause(){
        if(!GameManager.instance.isPaused)
        {
            TogglePause();
            pauseMenu.SetActive(true);
        }
    }
    //the below handles the game pausing when the app loses focus
    void OnApplicationFocus(bool focusStatus) {
        if(!focusStatus)
        {
            ForceFocusPause();
        }
    }
        void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
        {
            ForceFocusPause();
        }
    }
}