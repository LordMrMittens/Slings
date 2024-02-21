using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool canDisappear = false;
    public Renderer rend {get; protected set;}
    public SpriteRenderer spriteRenderer {get; protected set;}
    protected virtual void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }


    // Update is called once per frame
    protected virtual void Update()
    {
        if(rend.isVisible){
            canDisappear = true;
        }
        if(canDisappear && rend.isVisible == false){
           if(transform.parent != null){
               Destroy(transform.parent.gameObject);
           }
            Destroy(gameObject);
        }
    }
}
