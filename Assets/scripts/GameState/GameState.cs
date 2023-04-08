using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int State;
    GameObject[] Spawners;
    private void Start()
    {      
        Spawners = GameObject.FindGameObjectsWithTag("Spawners");
    }
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().AdvanceLevel += AdjustDifficulty;  
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>()!=null)
        {
            FindObjectOfType<GameManager>().AdvanceLevel -= AdjustDifficulty;   
        }    
    }
    private void Update()
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
   

