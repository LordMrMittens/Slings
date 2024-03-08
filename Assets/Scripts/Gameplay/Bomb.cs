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
    public class OnExplodeEvent : UnityEvent<GameObject> { }
    public OnExplodeEvent OnExplode = new OnExplodeEvent();
    //add score value to this event when called
    public class OnDisableEvent : UnityEvent<int> { }
    public OnDisableEvent OnDisable = new OnDisableEvent();
    public GameObject Target { get; set; }
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Vector3 explosionOffset = new Vector3(0, .5f, 0);

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
        OnExplode.Invoke(Target);
        GameObject explosion = Instantiate(explosionPrefab, transform.position + explosionOffset, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
    public void Disable(Vector3 direction, int points =0)
    {
        Vector3 flyDirection = direction * flyAwaySpeedOffset;
        flyDirection.y += flyAwayVerticalOffset;
        transform.parent = null;
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.AddForce(flyDirection, ForceMode2D.Impulse);
        bCanExplode = false;
        circleCollider.enabled = false;
        OnDisable.Invoke(1+points);
    }
}
