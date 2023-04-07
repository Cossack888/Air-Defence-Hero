using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    TargetingSystem system;
   
    public float speed = 40f;
    
    public Vector3 target;
    public Vector3 aim;
    public Vector2 targetPos;
    
    public GameObject projectile;
    
    void Start()
    {
        
        PickTarget();
        
        projectile = gameObject;
    }


    private void OnEnable()
    {
        FindObjectOfType<GameManager>().advanceLevel += SetSpeed;
    }
    private void OnDisable()
    {
       if (FindObjectOfType<GameManager>() != null){
            FindObjectOfType<GameManager>().advanceLevel -= SetSpeed;
        }
       
    }
    private void FixedUpdate()
    {
      
            Rotation();
        
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, aim, step);
        if (transform.position == aim)
        {
            projectile.SetActive(false);
        }
    }

    

    public void Rotation()
    {
        targetPos = target - transform.position;
        float rotZ = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }
    public void PickTarget()
    {
        system = FindObjectOfType<TargetingSystem>();
        target = system.target;
        aim = new Vector2(target.x, target.y);
    }

    public void SetSpeed(int level)
    {
        
        speed = 5+level*2;
    }

}
