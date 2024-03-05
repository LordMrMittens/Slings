using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Slingshot slingShotPrefab;
    [SerializeField] Bullet projectilePrefab;
    Launcher launcher;
    void Start()
    {
        launcher = GetComponent<Launcher>();
    }
    //the below is done this way and not directily from the input handler in case shot modifiers are added in later iterations
    public void PrepareLauncher(Vector3 position)
    {
        launcher.ActivateSlingshot(new Vector3(position.x,position.y,0),slingShotPrefab,projectilePrefab);
    }
    public void DragAction(Vector3 position)
    {
        launcher.Drag(position);
    }

    public void ShootAction()
    {
        launcher.Shoot();
    }
    
}
