using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    [SerializeField] float swaySpeed = 3;
    [SerializeField] float swayDistanceInAngles = 40;
    [SerializeField] float maxOffset =2, minOffset = -2;
    [SerializeField] float maxSteerHeight = .5f, minSteerHeight = -1.5f;
    float steerHeight;
    [SerializeField] float steerSpeed = 1;
    [SerializeField] Bomb bomb;
    Rigidbody2D rb;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset = Random.Range(minOffset, maxOffset);
        bomb.OnDisable.AddListener(DetachFromBomb);
        steerHeight = Random.Range(minSteerHeight, maxSteerHeight);
    }
    void Update()
    {
        Sway();
        
    }
    private void FixedUpdate() {
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
    void Steer()
    {
        if (transform.position.y > 1.5f)
        {
            if (transform.position.x < GameManager.instance.screenBounds.x + .5f)
            {
                rb.AddForce(Vector2.left * 2, ForceMode2D.Force);
            }
            else if (transform.position.x > -GameManager.instance.screenBounds.x - .5f)
            {
                rb.AddForce(Vector2.right * 2, ForceMode2D.Force);
            }
        } else {
            GameObject[] ActiveIcons = GameManager.instance.livesManager.GetActiveLifeIconTransforms().ToArray();
            if (ActiveIcons.Length > 0 && transform.position.y < steerHeight)
            {
                GameObject nearestIcon = GetClosestIcon(ActiveIcons);
                Vector2 direction = (nearestIcon.transform.position - transform.position).normalized;
                direction.y = 0;
                rb.AddForce(direction * steerSpeed, ForceMode2D.Force);
            }
        }
    }

    private GameObject GetClosestIcon(GameObject[] ActiveIcons)
    {
        GameObject nearestIcon = ActiveIcons[0];
        float nearestDistance = Vector2.Distance(transform.position, nearestIcon.transform.position);
        foreach (GameObject icon in ActiveIcons)
        {
            float distance = Vector2.Distance(transform.position, icon.transform.position);
            if (distance < nearestDistance)
            {
                nearestIcon = icon;
                nearestDistance = distance;
            }
        }
        bomb.Target = nearestIcon;
        return nearestIcon;
    }
    void AddMass(float massToAdd){
        rb.mass += massToAdd;
    }
}
