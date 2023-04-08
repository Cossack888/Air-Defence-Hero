using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaTrajectory : MonoBehaviour
{
    private Vector3 MousePos;
    private Rigidbody2D rb;
    public float speed;
    Vector3 direction;
    public void BulletTrajectory()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        direction = MousePos - transform.position;
        Vector3 rotation = transform.position - MousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;  
    }
}
