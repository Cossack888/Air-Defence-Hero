using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCount : MonoBehaviour
{

    public Text points;
    public Text finalPoints;
    public int pointsCount;
    // Start is called before the first frame update
    void Start()
    {
        points.text = "0";
    }

    // Update is called once per frame
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
