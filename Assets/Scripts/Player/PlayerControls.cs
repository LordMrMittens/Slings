using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Slingshot slingShotPrefab;
    [SerializeField] Bullet projectilePrefab;
    [SerializeField] float defaultTimeBetweenShots = 0.25f;
    float currentTimeBetweenShots;
    float timeBetweenShots;
    float timeSinceLastShot = 0;
    Launcher launcher;

    void Start()
    {
        launcher = GetComponent<Launcher>();
        currentTimeBetweenShots = defaultTimeBetweenShots;
        ResetTimeBetweenShots();
    }
    //the below is done this way and not directily from the input handler in case shot modifiers are added in later iterations
    public void PrepareLauncher(Vector3 position)
    {
        Debug.Log($"isPaused: {GameManager.instance.isPaused},Time:{Time.time} ,timeSinceLastShot: {timeSinceLastShot}, timeBetweenShots: {timeBetweenShots}");
        if (GameManager.instance.isPaused || Time.time - timeSinceLastShot < timeBetweenShots) return;
        launcher.ActivateSlingshot(new Vector3(position.x,position.y,0),slingShotPrefab,projectilePrefab);
    }
    public void HandleDragAction(Vector3 position)
    {
        launcher.Drag(position);
    }

    public void HandleShootAction()
    {
        timeSinceLastShot = launcher.Shoot() ? Time.time : timeSinceLastShot;
    }
    public void SetTimeBetweenShots(float time)
    {
        currentTimeBetweenShots = timeBetweenShots;
        timeBetweenShots = time;
    }
    public void ResetTimeBetweenShots()
    {
        timeBetweenShots = currentTimeBetweenShots == defaultTimeBetweenShots ? defaultTimeBetweenShots : currentTimeBetweenShots;
    }
    
}
