using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerControls playerControls;
    public Touch touch;

    void Start()
    {
        playerControls = GetComponent<PlayerControls>();
        touch = new Touch();
    }

    // Update is called once per frame
    void Update()
    {
        RegisterGameplayInputs();
        RegisterOtherInputs();
    }
    private void RegisterOtherInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.TogglePause();
        }
    }
    private void RegisterGameplayInputs()
    {
        //for touch input
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ValidatePosition(HandleInput(touch.position));
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                playerControls.HandleDragAction(HandleInput(touch.position));
            }
            if (touch.phase == TouchPhase.Ended)
            {
                playerControls.HandleShootAction();
            }
        }
        //for mouse input
        else if (Input.GetMouseButtonDown(0))
        {
            ValidatePosition(HandleInput(Input.mousePosition));
        }
        if(Input.GetMouseButton(0)){
            playerControls.HandleDragAction(HandleInput(Input.mousePosition));
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerControls.HandleShootAction();
        }
    }

    private void ValidatePosition(Vector3 mousePos)
    {
        if (mousePos.y < 0)
        {
            playerControls.PrepareLauncher(new Vector3(mousePos.x, mousePos.y, 0));
        }
    }
    Vector3 HandleInput(Vector3 position)
    {
    return Camera.main.ScreenToWorldPoint(position);
    
    }
}
