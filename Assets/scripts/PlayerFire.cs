using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    public GameObject ammo;
    public int ammoCount;
    public Text ammoDisplay;
    public int cannonID;
   
    void Update()
    {
        shoot();  
    }


    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            ammoCount--;
            if (ammoCount > 0)
            {
                ammoDisplay.text = ammoCount.ToString();
                GetFromPool();
            }

            else { ammoDisplay.text = "Empty"; }
        }
    }

    void GetFromPool()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
           PlasmaTrajectory trajectory =  bullet.GetComponent<PlasmaTrajectory>() ;
            trajectory.BulletTrajectory();
            PlasmaShot shot = bullet.GetComponent<PlasmaShot>();
            shot.cannonID = cannonID;
        }
    }


}
