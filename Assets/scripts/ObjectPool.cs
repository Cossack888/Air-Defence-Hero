using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    List<GameObject> missiles;
    List<GameObject> planes;
    List<GameObject> plasmaBullets;
    [SerializeField]GameObject missile;
    [SerializeField] GameObject plane;
    [SerializeField] GameObject plasmaBullet;

    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        missiles = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(missile);
            tmp.SetActive(false);
            missiles.Add(tmp);
        }
        planes = new List<GameObject>();
        GameObject tmp1;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp1 = Instantiate(plane);
            tmp1.SetActive(false);
            planes.Add(tmp1);
        }
        plasmaBullets = new List<GameObject>();
        GameObject tmp2;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp2 = Instantiate(plasmaBullet);
            tmp2.SetActive(false);
            plasmaBullets.Add(tmp2);
        }
    }

    public GameObject GetPooledMissile()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!missiles[i].activeInHierarchy)
            {
                return missiles[i];
            }
        }
        return null;
    }
    public GameObject GetPooledPlane()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!planes[i].activeInHierarchy)
            {
                return planes[i];
            }
        }
        return null;
    }
    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!plasmaBullets[i].activeInHierarchy)
            {
                return plasmaBullets[i];
            }
        }
        return null;
    }



}
