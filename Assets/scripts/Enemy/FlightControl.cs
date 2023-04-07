using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    TargetingSystem system;
    Vector3 course;
    float speed;
    float xPosition;
    float yPosition;
    public bool m_FacingRight;
    Bombing bomb;
    [SerializeField] Vector2 FinalDestination;
     
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
        speed = 10;
        SetCourse();
    }
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = m_FacingRight;
        MovementAfterBomb();
        course = new Vector3(xPosition, yPosition);
        float step = speed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, course, step);  
    }
    void MovementAfterBomb()
    {
        if (bomb.bombDropped)
        {
            yPosition = 60;
            xPosition = FinalDestination.x * (m_FacingRight ? 1 : -1);
            if (transform.position.x == xPosition)
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
