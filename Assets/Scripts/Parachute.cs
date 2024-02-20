using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    [SerializeField] float swaySpeed = 3;
    [SerializeField] float swayDistanceInAngles = 40;
    [SerializeField] float maxOffset =2, minOffset = -2;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Random.Range(minOffset, maxOffset);
    }

    // Update is called once per frame
    void Update()
    {
        Sway();
        //move bomb side to side
        //alternate direction of bomb fall
        //stay away from walls
        //optional - steer towards target
    }
    void Sway(){
        // add random offset so sway is not uniform

        float angle = Mathf.Sin(Time.time * (swaySpeed + offset)) * swayDistanceInAngles;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }
}
