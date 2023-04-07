using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaShot : MonoBehaviour
{

    GameObject bullet;
    PointCount counter;
   public GameObject gun;
    int XPincreaseFactor;

    private void Start()
    {
        counter = FindObjectOfType<PointCount>();
        bullet = gameObject;
    }
    private void OnEnable()
    {  
        FindObjectOfType<GameManager>().advanceLevel += SetLevel;
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>() != null)
        {
            FindObjectOfType<GameManager>().advanceLevel -= SetLevel;
        }
    }

    void SetLevel(int level)
    {
        XPincreaseFactor = level;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            collision.gameObject.SetActive(false);
            bullet.SetActive(false);
            AddPoints(1+XPincreaseFactor);
        }
        if (collision.gameObject.CompareTag("Target"))
        {
            
            bullet.SetActive(false);
            AddPoints(-5);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            collision.gameObject.SetActive(false);
            bullet.SetActive(false);

            AddPoints(2 + XPincreaseFactor);
            AddAmmo();
            
            
        }
    }
    void Update()
    {
       if(transform.position.y>100|| transform.position.x > 100 || transform.position.x < -100)
        {
            bullet.SetActive(false);
        }
    }
    public void AddAmmo()
    {
       gun.GetComponentInChildren<PlayerFire>().ammoCount += 3;
        
    }
    void AddPoints(int points)
    {
        counter.pointsCount += points;
    }
}
