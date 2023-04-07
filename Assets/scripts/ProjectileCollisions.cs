using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisions : MonoBehaviour
{
    public GameObject projectile;
    
    private void Start()
    {
        projectile = gameObject;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            projectile.SetActive(false);

        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            projectile.SetActive(false);

        }
    }
}
