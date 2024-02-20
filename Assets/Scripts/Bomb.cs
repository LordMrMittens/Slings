using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    bool bCanExplode = true;
    CircleCollider2D circleCollider;
    Rigidbody2D rb;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(transform.position.y < (GameManager.instance.screenBounds.y * -1)+.5f && bCanExplode)
        {
            Explode();
        }
    }
    public void Explode()
    {
        Destroy(gameObject);
    }
    public void Disable(Vector3 direction)
    {
        rb.gravityScale = 0;
        rb.AddForce(direction, ForceMode2D.Impulse);
        bCanExplode = false;
        circleCollider.enabled = false;

        // launch toward the sky and edges of screen
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Projectile")
        {
            Vector3 velocity = other.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector3 direction = (other.transform.position - transform.position) * velocity.magnitude;
            Disable(direction);
        }
    }
}
