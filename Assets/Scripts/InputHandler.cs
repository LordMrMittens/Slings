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
        RegisterInputs();
    }

    private void RegisterInputs()
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
                playerControls.DragAction(HandleInput(touch.position));
            }
            if (touch.phase == TouchPhase.Ended)
            {
                playerControls.ShootAction();
            }
        }
        //for mouse input
        else if (Input.GetMouseButtonDown(0))
        {
            ValidatePosition(HandleInput(Input.mousePosition));
        }
        if(Input.GetMouseButton(0)){
            playerControls.DragAction(HandleInput(Input.mousePosition));
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerControls.ShootAction();
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
