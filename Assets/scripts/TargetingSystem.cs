using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    float timer;
    [SerializeField] float delay;
    public Vector3 target;
    GameObject[] CityPoints;
    List<Transform> CityLocations;
    bool gameFinished;
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
        timer += Time.deltaTime;
        if (timer > delay&&!gameFinished)
        {
            ChooseTarget();
            timer = 0;
        }
    }
    void ChooseTarget()
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
    void RemoveTarget()
    {
        for (var i = CityLocations.Count - 1; i > -1; i--)
        {
            if (CityLocations[i] == null)
            {
                CityLocations.RemoveAt(i);
                ChooseTarget();
            }  
        }
    }
}
