using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    float timer;
    public float delay;
    public Vector3 target;
    public GameObject[] CityPoints;
    List<Transform> CityLocations;
    public bool gameFinished;

    void Start()
    {
        CityLocations = new List<Transform>();
        CityPoints = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject CityPoint in CityPoints)
        {
            CityLocations.Add(CityPoint.transform);
        }
        ChooseTarget();
        
    }

    void Update()
    {
        RemoveTarget();
        timer = timer + Time.deltaTime;
        if (timer > delay&&!gameFinished)
        {
         
            ChooseTarget();
            timer = 0;
            
        }

    }

    public void ChooseTarget()
    {

        if (CityLocations.Count  > 1)
        {
            target = CityLocations[Random.Range(0, CityLocations.Count - 1)].position;
        }
        if (CityLocations.Count == 1)
        {
            target = CityLocations[0].position;
        }
        if (CityLocations.Count == 0)
        {
            gameFinished = true;
        }
    }

    public void RemoveTarget()
    {
        for (var i = CityLocations.Count - 1; i > -1; i--)
        {
            if (CityLocations[i] == null)
                CityLocations.RemoveAt(i);
        }
    }

}
