using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public TargetingSystem system;
   // public GameManager game;
    public Vector3 course;
    public float speed;
    public float xPosition;
    public float yPosition;
    public bool m_FacingRight;
    public Bombing bomb;
    public Vector2 FinalDestination;
    public Rigidbody2D rb;
   
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().advanceLevel += SetSpeed;
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>() != null)
        {
            FindObjectOfType<GameManager>().advanceLevel -= SetSpeed;
        }
            
    }

    private void Start()
    {
        system = FindObjectOfType<TargetingSystem>();
        bomb = GetComponent<Bombing>();
        SetCourse();
    }
    void Update()
    {

         if (m_FacingRight)
         {
             GetComponent<SpriteRenderer>().flipX = true;
         }
         else if (!m_FacingRight)
         {
             GetComponent<SpriteRenderer>().flipX = false;
         }

        

        MovementAfterBomb();
        course = new Vector3(xPosition, yPosition);
        float step = speed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, course, step);
        
    }
    public void MovementAfterBomb()
    {
        if (bomb.bombDropped)
        {
            yPosition = 60;
            if (m_FacingRight)
            {
                xPosition = FinalDestination.x;
            }
            else if (!m_FacingRight)
            {
                xPosition = -FinalDestination.x;
            }

            if(transform.position.x == xPosition)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void SetCourse()
    {
        
        
        bomb.bombDropped = false;
        xPosition = system.target.x;
        yPosition = system.target.y + bomb.altiutdeForDrop;
        
    }
    public void SetSpeed(int level)
    {
        
        speed = 10+level*2;
    }




}
