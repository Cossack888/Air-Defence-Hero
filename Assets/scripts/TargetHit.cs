using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    int health;
    [SerializeField] int maxHealth=3;
    private void Start()
    {
        health = maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile")|| (collision.gameObject.CompareTag("Plasma")))
        {
            if (health > 0)
            {
                TakeDamage(1);
            }
            if (health == 0)
            {
                Destroy(gameObject);    
            }
        }
    }
    void TakeDamage(int dmg)
    {
        health -= dmg;   
    }
  
}
