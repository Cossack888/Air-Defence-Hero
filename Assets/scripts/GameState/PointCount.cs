using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCount : MonoBehaviour
{
    [SerializeField] Text points;
    [SerializeField] Text finalPoints;
    public int pointsCount;
    void Start()
    {
        points.text = "0";
    }
    void Update()
    {
        points.text = "You have "+ pointsCount.ToString() + " Points";
        finalPoints.text = "The City has fallen. All is lost but you managed to score " + pointsCount.ToString() + " points. Better luck next time";
    }
    public void AddPoints(int pointAmmount)
    {
        pointsCount += pointAmmount;
    }
}
