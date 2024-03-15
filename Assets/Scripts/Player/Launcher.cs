using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SlingshotType{
    Fixed,
    Free
}
public class Launcher : MonoBehaviour
{
    SlingshotType slingshotType = SlingshotType.Free;
    Bullet projectile;
    Slingshot slingShot;
    [SerializeField] float forceOffset = 10;
    void Start()
    {
        slingShot = FindObjectOfType<Slingshot>();
        if(slingShot)
        {
            slingshotType = SlingshotType.Fixed;
            slingShot.DeactivateLineRenderers();
        }
    }
    public void Drag(Vector3 pos)
    {
        if(projectile == null || slingShot == null) return;
        pos.z = 0;
        projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, pos, 0.5f);
        slingShot.UpdatePullingPosition(projectile.transform.position);
        if (slingshotType == SlingshotType.Free)
        {
            slingShot.transform.up = pos - transform.position;
        }
    }

    public void ActivateSlingshot(Vector3 position, Slingshot SlingShotPrefab, Bullet ProjectilePrefab)
    {
        if(slingshotType == SlingshotType.Free)
        {
            CreateSlingShot(position, SlingShotPrefab, ProjectilePrefab);
        }else{
            SpawnFixedSlingshotProjectile(position, ProjectilePrefab);
            slingShot.ActivateLineRenderers();
        }

    }
    void CreateSlingShot(Vector3 position, Slingshot SlingShotPrefab, Bullet ProjectilePrefab)
    {
        if(slingShot != null) return;
        slingShot = Instantiate(SlingShotPrefab, position, Quaternion.identity);
        projectile = Instantiate(ProjectilePrefab, position, Quaternion.identity);
        slingShot.ActivateLineRenderers();
    }
    public bool Shoot(){
        if(slingShot == null || projectile == null) return false;
        Vector3 force = (slingShot.ShootingAxis.position - projectile.transform.position ) * forceOffset;
        projectile.ShootBullet(force);
        slingShot.DeactivateLineRenderers();
        DestroySlingShot();
        return true;
    }
    void DestroySlingShot()
    {
        projectile = null;
        if(slingshotType == SlingshotType.Fixed) return;
        Destroy(slingShot,1f);
        slingShot = null;
    }
    void SpawnFixedSlingshotProjectile(Vector3 position, Bullet ProjectilePrefab)
    {
        projectile = Instantiate(ProjectilePrefab, position, Quaternion.identity);
    }
}
