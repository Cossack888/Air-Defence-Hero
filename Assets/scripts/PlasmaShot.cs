using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaShot : MonoBehaviour
{
   
    
    public GameObject bullet;
    public int cannonID;
    public PointCount counter;
    public GameManager game;

    private void Start()
    {
        counter = FindObjectOfType<PointCount>();
        game = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            collision.gameObject.SetActive(false);
            bullet.SetActive(false);
            AddPoints(1+game.level);
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

            AddPoints(2 + game.level);
            AddAmmo();
            
            
        }
    }


    // Update is called once per frame
    void Update()
    {
       if(transform.position.y>100|| transform.position.x > 100 || transform.position.x < -100)
        {
            bullet.SetActive(false);
        }
    }
   

    public void AddAmmo()
    {
        if (GameObject.Find("AntiMissile" + cannonID))
        {
            GameObject.Find("AntiMissile" + cannonID).GetComponentInChildren<PlayerFire>().ammoCount += 3;
        }
    }
    void AddPoints(int points)
    {
        counter.pointsCount += points;
    }
}
