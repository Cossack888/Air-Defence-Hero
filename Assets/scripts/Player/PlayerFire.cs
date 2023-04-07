using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{   
    public int ammoCount;
    [SerializeField]Text ammoDisplay;

    private void Start()
    {
        ammoCount = 40;
    }
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
                GetBulletFromPool();
            }
            else { ammoDisplay.text = "Empty"; }
        }
    }

    void GetBulletFromPool()
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
            shot.gun = gameObject;
        }
    }


}
