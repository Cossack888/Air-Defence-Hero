using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ButtonFunctions gameManagementFunctions;
    [SerializeField] float levelAdvancementPoints = 20;
    GameObject[] CityPoints;
    PointCount counter;
    int level;
    public int startingCityPoints;
    float timer = 0;
    public delegate void OnGameStateChange(int number);
    public event OnGameStateChange advanceLevel;
    public event OnGameStateChange cityPointsRemaining;

    private void Start()
    {
        CityPoints = GameObject.FindGameObjectsWithTag("Target");
        counter = GetComponent<PointCount>();
        startingCityPoints = 6;
        Time.timeScale = 1f;
        startingCityPoints = CityPoints.Length;
        gameManagementFunctions = GetComponent<ButtonFunctions>();
    }
    private void Update()
    {
        if (counter.pointsCount > levelAdvancementPoints)
        {
            AdvanceLevel();
        }
        CityPoints = GameObject.FindGameObjectsWithTag("Target");
        if (CityPoints.Length < startingCityPoints)
        {
            startingCityPoints--;
            cityPointsRemaining.Invoke(CityPoints.Length);
        }
        if (CityPoints.Length == 0)
        {
            timer += Time.deltaTime;
            cityPointsRemaining.Invoke(CityPoints.Length);
            gameManagementFunctions.ActivateGameOverMenu();
            if (timer > 5)
            {
                gameManagementFunctions.PauseGame();
            }
        }
    }
    void AdvanceLevel()
    {
        gameManagementFunctions.PauseGame();
        level++;
        advanceLevel.Invoke(level);
        levelAdvancementPoints += levelAdvancementPoints * 1.5f;
        AddPointsForCityLocations();
    }
    void AddPointsForCityLocations()
    {
        counter.AddPoints(CityPoints.Length * level);
    }
}

