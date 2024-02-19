using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    bool bCanExplode = true;
    public void Explode()
    {
        //play animation
        //take "life" away
        //destroy 
    }

    public void Disable()
    {
        bCanExplode = false;
        // launch toward the sky and edges of screen
    }
}
