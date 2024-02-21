using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : Projectile
{
    bool bCanExplode = true;
    CircleCollider2D circleCollider;

    [SerializeField] float flyAwaySpeedOffset = 10;
    [SerializeField] float flyAwayVerticalOffset = 5;
    public UnityEvent OnExplode;
    
    public UnityEvent OnDisable;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        
    }
    protected override void Update()
    {
        base.Update();
        if (bCanExplode)
        {
            if (transform.position.y < GameManager.instance.screenBounds.y + .5f)
            {
                Explode();
            }
        }
    }
    public void Explode()
    {
        OnExplode.Invoke();
        Destroy(gameObject);
    }
    public void Disable(Vector3 direction)
    {
        transform.parent = null;
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.AddForce(direction, ForceMode2D.Impulse);
        bCanExplode = false;
        circleCollider.enabled = false;
        OnDisable.Invoke();
        // launch toward the sky and edges of screen
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Projectile")
        {
            Vector3 direction = ( transform.position - other.transform.position ).normalized * flyAwaySpeedOffset;
            direction.y+=flyAwayVerticalOffset;
            Disable(direction);
        }
    }
}
