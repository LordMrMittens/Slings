using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    Bullet projectile;
    GameObject slingShot;
    [SerializeField] float forceOffset = 10;
    void Update()
    {
        if (Input.GetMouseButton(0)&& slingShot != null && projectile != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            slingShot.transform.up = mousePos - transform.position;
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, mousePos, 0.1f);
        }
    }
    public void CreateSlingShot(Vector3 position, GameObject SlingShotPrefab, Bullet ProjectilePrefab)
    {
        if(slingShot != null) return;
        slingShot = Instantiate(SlingShotPrefab, position, Quaternion.identity);
        projectile = Instantiate(ProjectilePrefab, position, Quaternion.identity);
    }
    public void Shoot(){
        if(slingShot == null || projectile == null) return;
        Vector3 force = (slingShot.transform.position - projectile.transform.position ) * forceOffset;
        projectile.ShootBullet(force);
        DestroySlingShot();
    }
    void DestroySlingShot()
    {
        projectile = null;
        Destroy(slingShot,1f);
        slingShot = null;
    }
}
