using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    public Sprite neutral;
    public Sprite angry;
    public Sprite bored;
    public Sprite sad;
    public Sprite scared1;
    public Sprite scared2;
    public Sprite scared3;
    public Sprite scared4;
    public Sprite supprised;
    public Sprite confused;
    public Sprite crying;
    public Sprite disgusted;
    public Sprite eyesClosed;
    public Sprite eyeClosed;
    public Sprite happy;
    public Sprite happy2;
    public Sprite inLove;
    public int soldierMood;
    public SpriteRenderer spriteRend;

    private void OnEnable()
    {
        
        FindObjectOfType<GameManager>().cityPointsRemaining += CityDestroyed;
        FindObjectOfType<GameManager>().advanceLevel += GameAdvancement;
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>() != null)
        {
            
            FindObjectOfType<GameManager>().cityPointsRemaining -= CityDestroyed;
            FindObjectOfType<GameManager>().advanceLevel += GameAdvancement;
        }

    }

    private void Start()
    {
        ChangeFace(0);
    }
    public void GameAdvancement(int level)
    {
       

        if (level > 1 && level < 5)
        {
            ChangeFace(14);
        }
        if (level >= 5 && level < 10)
        {
            ChangeFace(15);
        }
        if (level >= 10 && level < 20)
        {
            ChangeFace(16);
        }

    }

    public void CityDestroyed(int cityCount)
    {
        if (cityCount == 5)
        {
            ChangeFace(3);
        }
        if (cityCount == 4)
        {
            ChangeFace(4);
        }
        if (cityCount == 3)
        {
            ChangeFace(5);
        }
        if (cityCount == 2)
        {
            ChangeFace(6);
        }
        if (cityCount == 1)
        {
            ChangeFace(7);
        }
        if (cityCount == 0)
        {
            ChangeFace(10);
        }
    }

    public void ChangeFace(int soldierMood)
    {
        switch (soldierMood)
        {

            case 0:
                spriteRend.sprite = neutral;


                break;
            case 1:
                spriteRend.sprite = angry;


                break;
            case 2:
                spriteRend.sprite = bored;

                break;
            case 3:
                spriteRend.sprite = sad;


                break;
            case 4:
                spriteRend.sprite = scared1;


                break;
            case 5:
                spriteRend.sprite = scared2;


                break;
            case 6:
                spriteRend.sprite = scared3;


                break;
            case 7:
                spriteRend.sprite = scared4;


                break;
            case 8:
                spriteRend.sprite = supprised;


                break;
            case 9:
                spriteRend.sprite = confused;


                break;
            case 10:
                spriteRend.sprite = crying;


                break;
            case 11:
                spriteRend.sprite = disgusted;


                break;
            case 12:
                spriteRend.sprite = eyeClosed;


                break;
            case 13:
                spriteRend.sprite = eyesClosed;


                break;
            case 14:
                spriteRend.sprite = happy;


                break;
            case 15:
                spriteRend.sprite = happy2;


                break;
            case 16:
                spriteRend.sprite = inLove;


                break;
            

            default:
                spriteRend.sprite = neutral;
                break;
        }
    }

}
