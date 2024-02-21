using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed {get;set;}
    bool bCanDespawn = false;
    Renderer rend;
    private void Start() {
        rend = gameObject.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if(bCanDespawn && rend.isVisible == false){
            Destroy(gameObject);
        }
        if(rend.isVisible){
            bCanDespawn = true;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
