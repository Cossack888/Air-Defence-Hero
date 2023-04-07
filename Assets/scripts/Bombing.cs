using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : MonoBehaviour
{
    TargetingSystem system;
    Vector2 target;
    public bool bombDropped;
    public int altiutdeForDrop=30;

    private void Start()
    {
        system = FindObjectOfType<TargetingSystem>();       
        target = system.target;

    }
    private void Update()
    {

        if (transform.position.y == target.y+altiutdeForDrop && !bombDropped)
        {
            GameObject missile = ObjectPool.SharedInstance.GetPooledMissile();
            if (missile != null)
            {
                missile.transform.position = transform.position;
                missile.transform.rotation = transform.rotation;
                missile.SetActive(true);
                missile.GetComponent<ProjectileMovement>().PickTarget();

            }
            bombDropped = true;
            
        }
    }
}
