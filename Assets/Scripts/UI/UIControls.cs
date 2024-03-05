using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    public void TogglePause()
    {
        GameManager.instance.TogglePause();
    }
}
