using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    [SerializeField] float swaySpeed = 3;
    [SerializeField] float swayDistanceInAngles = 40;
    [SerializeField] float maxOffset =2, minOffset = -2;
    [SerializeField] Bomb bomb;
    Rigidbody2D rb;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset = Random.Range(minOffset, maxOffset);
        bomb.OnDisable.AddListener(DetachFromBomb);
    }
    void Update()
    {
        Sway();
        Steer();
    }
    void Sway(){
        float angle = Mathf.Sin(Time.time * (swaySpeed + offset)) * swayDistanceInAngles;
        transform.rotation = Quaternion.Euler(0, 0, angle);     
    }
    void DetachFromBomb(int placeholder){
        rb.gravityScale = -2;
        Destroy(gameObject,3f);
    }
    void Steer(){
        if (transform.position.x < GameManager.instance.screenBounds.x +.5f)
        {
            rb.AddForce(Vector2.left * 2, ForceMode2D.Force);
        }
        else if (transform.position.x > -GameManager.instance.screenBounds.x -.5f)
        {
            rb.AddForce(Vector2.right * 2, ForceMode2D.Force);
        }
    }
}
