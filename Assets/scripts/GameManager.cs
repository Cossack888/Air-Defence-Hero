using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



    public class GameManager : MonoBehaviour
    {
    public ButtonFunctions gameManagementFunctions;
    public GameState state;
    public float levelAdvancementPoints=20;
        public GameObject[] turrets;
    public GameObject[] CityPoints;
    public PointCount counter;
    public int level;
    public int startingCityPoints;  
    public float timer = 0;
    public int targetsLeft;
    public delegate void OnGameStateChange(int number);
    public event OnGameStateChange advanceLevel;
    public event OnGameStateChange cityPointsRemaining;



    private void Start()
    {
        
        counter = GetComponent<PointCount>();
        state = FindObjectOfType<GameState>();
        startingCityPoints = 6;
        Time.timeScale = 1f;
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
     
    public void AdvanceLevel()
    {
        gameManagementFunctions.PauseGame();
        level++;
        advanceLevel.Invoke(level);
        
        levelAdvancementPoints += levelAdvancementPoints * 1.5f;
        AddPointsForCityLocations();
        
    }
    public void AddPointsForCityLocations()
    {
        
            counter.AddPoints(CityPoints.Length*level);
        
    }


   

}

