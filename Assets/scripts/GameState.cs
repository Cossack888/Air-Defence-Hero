using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    
   
    public GameManager manager;
    public int level;
    public int State;
    public GameObject[] Spawners;
  

    public void Start()
    {
        
        manager = FindObjectOfType<GameManager>();
        Spawners = GameObject.FindGameObjectsWithTag("Spawners");
    }
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().advanceLevel += AdjustDifficulty;
        
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>()!=null)
        {
            FindObjectOfType<GameManager>().advanceLevel -= AdjustDifficulty;
           
        }
        
    }

   

   
    public void Update()
    {
        foreach (GameObject spawner in Spawners)
        {
            spawner.GetComponent<Spawner>().delay = 4 - State;
        }

    }

    void AdjustDifficulty(int level)
    {
        

        if (level > 1 && level < 5)
        {
            State = 1;


        }
        else if (level >= 5 && level < 10)
        {
            State = 2;

        }
        else if (level >= 10 && level < 20)
        {
            State = 3;

        }
    }




}
   

