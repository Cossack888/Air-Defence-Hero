using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    float timer;
    public float delay;
    public int randX1;
    public int randX2;
    public int randY1;
    public int randY2;
    public bool FacingRight;
    public Vector3 startingTarget;
    public enum Pools {planes,missiles};
    [SerializeField]
    Pools pool = new Pools();

   


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            int xPosition = Random.Range(randX1,  randX2);
            int yPosition = Random.Range(randY1, randY2);
            GetFromPool(xPosition,yPosition);
            timer = 0;
        }
    }

  
    void GetFromPool(int xPos, int yPos)
    {


        try
        {
            switch (pool)
            {
                case Pools.planes:
                    GameObject plane = ObjectPool.SharedInstance.GetPooledPlane();
                    if (plane != null)
                    {
                        plane.transform.position = new Vector2(xPos, yPos);
                        plane.transform.rotation = transform.rotation;
                        plane.SetActive(true);
                        plane.GetComponent<FlightControl>().m_FacingRight = FacingRight;
                        plane.GetComponent<FlightControl>().SetCourse();
                        
                       
                    }
                    break;

                case Pools.missiles:
                    GameObject missile = ObjectPool.SharedInstance.GetPooledMissile();
                    if (missile != null)
                    {
                        missile.transform.position = new Vector2(xPos, yPos);
                        missile.transform.rotation = transform.rotation;
                        missile.SetActive(true);
                        missile.GetComponent<ProjectileMovement>().PickTarget();
                        
                    }
                    break;
            }
        }

        catch
        {
            
        }
        
    }

    
   
}
