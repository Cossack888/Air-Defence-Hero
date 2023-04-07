using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestList : MonoBehaviour
{

    public Vector3 target;
    public GameObject[] CityPoints;
    private float timer;
    public float delay=5;
    // Start is called before the first frame update
    void Start()
    {
        ChooseTarget(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            
            ChooseTarget();
            timer = 0;

        }
    }


    public void ChooseTarget()
    {
        List<Transform> CityLocations = new List<Transform>();
        CityPoints = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject CityPoint in CityPoints)
        {
            CityLocations.Add(CityPoint.transform);
        }
        for (var i = CityLocations.Count - 1; i > -1; i--)
        {
            if (CityLocations[i] == null)
                CityLocations.RemoveAt(i);
        }

        if (CityLocations.Count - 1 >= 0)
        {
            target = CityLocations[Random.Range(0, CityLocations.Count - 1)].position;
        }
        if (CityLocations.Count == 0)
        {
            target = CityLocations[0].position;
        }
    }


}
