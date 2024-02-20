using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    GameObject projectile;
    GameObject slingShot;
    [SerializeField] float forceOffset = 10;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            slingShot.transform.LookAt(mousePos);
            projectile.transform.LookAt(mousePos);
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, mousePos, 0.1f);
        }
    }
    public void CreateSlingShot(Vector3 position, GameObject SlingShotPrefab, GameObject ProjectilePrefab)
    {
        //spawn elastic part of slingshot
        slingShot = Instantiate(SlingShotPrefab, position, Quaternion.identity);
        projectile = Instantiate(ProjectilePrefab, position, Quaternion.identity);
    }
    public void Shoot(){
        Vector3 force = (projectile.transform.position - slingShot.transform.position) * forceOffset; //make it an offset from the slingshot distance to the mouse
        projectile.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        DestroySlingShot();
    }
    void DestroySlingShot()
    {
        Destroy(slingShot,1f);
    }
}
