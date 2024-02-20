using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] GameObject slingShotPrefab;
    [SerializeField] GameObject projectilePrefab;
    Launcher launcher;
    void Start()
    {
        launcher = GetComponent<Launcher>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(mousePos.y < 0){
                    launcher.CreateSlingShot(new Vector3(mousePos.x,mousePos.y,0),slingShotPrefab,projectilePrefab);
                }
        }
        if(Input.GetMouseButtonUp(0)){
            launcher.Shoot();
        }
    }
    
}
