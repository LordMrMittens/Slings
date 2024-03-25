using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public bool bIsBeingGrabbed {get; private set;} = true;
    public int timesHit {get; private set ;} = 0;
    Rigidbody2D rb;
    [SerializeField] float rotationMinSpeed, rotationMaxSpeed;
    [SerializeField] Sprite[] BulletSprites;
    float rotationSpeed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        rotationSpeed = Random.Range(rotationMinSpeed, rotationMaxSpeed);
        SetSprite();
    }
        void SetSprite(){
        int index = Random.Range(0,BulletSprites.Length-1);
        spriteRenderer.sprite = BulletSprites[index];
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!bIsBeingGrabbed)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            base.Update();
        }
    }
    public void ShootBullet(Vector3 direction){
        bIsBeingGrabbed = false;
        rb.gravityScale = 1;
        rb.AddForce(direction, ForceMode2D.Impulse);
        }

    private void HandleBulletCollision(Collider2D other)
    {
        Bomb bomb = other.GetComponent<Bomb>();
        if (bomb)
        {
            if (bIsBeingGrabbed) return;
            Vector3 direction = (other.transform.position - transform.position).normalized;
            bomb.Disable(direction, timesHit);
            timesHit++;
            if (timesHit >= 8) return;
            AudioHandler.instance.PlayAudioEffect("Col" + timesHit.ToString());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleBulletCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other) {
        HandleBulletCollision(other);
    }
}
