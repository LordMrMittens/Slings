using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    [field : SerializeField] public GameObject pauseMenu;
    [field : SerializeField] public GameObject gameOverMenu;
    [field : SerializeField] public GameObject gamePanel;
    [field : SerializeField] public GameObject powerPanel;
    [field : SerializeField] public GameObject instructionPanel;


    public void TogglePause()
    {
        GameManager.instance.ToggleTimeStop();
    }
    public void ActivateGameOverMenu(int score)
    {
        gameOverMenu.SetActive(true);
        gamePanel.SetActive(false);
        powerPanel.SetActive(false);

    }
    public void DeactivateGameOverMenu()
    {
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
    public void DeactivateInstructionPanel(){

            instructionPanel.SetActive(false);
        
    }
}