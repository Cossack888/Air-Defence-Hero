using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    ButtonFunctions gameManagementFunctions;
    [SerializeField] float levelAdvancementPoints = 20;
    GameObject[] CityPoints;
    PointCount counter;
    [SerializeField] Text levelIndicator;
    int level;
    public int startingCityPoints;
    float timer = 0;
    public delegate void OnGameStateChange(int number);
    public event OnGameStateChange AdvanceLevel;
    public event OnGameStateChange CityPointsRemaining;
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
            LevelUp();
        }
        CityPoints = GameObject.FindGameObjectsWithTag("Target");
        if (CityPoints.Length < startingCityPoints)
        {
            startingCityPoints--;
            CityPointsRemaining.Invoke(CityPoints.Length);
        }
        if (CityPoints.Length == 0)
        {
            timer += Time.deltaTime;
            CityPointsRemaining.Invoke(CityPoints.Length);
            gameManagementFunctions.ActivateGameOverMenu();
            if (timer > 5)
            {
                gameManagementFunctions.PauseGame();
            }
        }
    }
    void LevelUp()
    {
        gameManagementFunctions.PauseGame();
        level++;
        levelIndicator.text = "Level "+level.ToString();
        AdvanceLevel.Invoke(level);
        levelAdvancementPoints += levelAdvancementPoints * 1.5f;
        AddPointsForCityLocations();
    }
    void AddPointsForCityLocations()
    {
        counter.AddPoints(CityPoints.Length * level);
    }
}

