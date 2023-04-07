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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            projectile.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Missile"))
        {
            projectile.transform.position = projectile.transform.position + new Vector3(0, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            projectile.SetActive(false);
        }
    }
    
}
