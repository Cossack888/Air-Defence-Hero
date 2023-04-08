using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    [SerializeField] Sprite neutral;
    [SerializeField] Sprite angry;
    [SerializeField] Sprite bored;
    [SerializeField] Sprite sad;
    [SerializeField] Sprite scared1;
    [SerializeField] Sprite scared2;
    [SerializeField] Sprite scared3;
    [SerializeField] Sprite scared4;
    [SerializeField] Sprite supprised;
    [SerializeField] Sprite confused;
    [SerializeField] Sprite crying;
    [SerializeField] Sprite disgusted;
    [SerializeField] Sprite eyesClosed;
    [SerializeField] Sprite eyeClosed;
    [SerializeField] Sprite happy;
    [SerializeField] Sprite happy2;
    [SerializeField] Sprite inLove;
    int soldierMood;
    public SpriteRenderer spriteRend;
    Dictionary<int, Sprite> moodSpriteMap = new Dictionary<int, Sprite>();
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().CityPointsRemaining += CityDestroyed;
        FindObjectOfType<GameManager>().AdvanceLevel += GameAdvancement;
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>() != null)
        {
            FindObjectOfType<GameManager>().CityPointsRemaining -= CityDestroyed;
            FindObjectOfType<GameManager>().AdvanceLevel -= GameAdvancement;
        }
    }
    private void InitializeSpriteMap()
    {
        moodSpriteMap[1] = neutral;
        moodSpriteMap[2] = angry;
        moodSpriteMap[3] = bored;
        moodSpriteMap[4] = sad;
        moodSpriteMap[5] = scared1;
        moodSpriteMap[6] = scared2;
        moodSpriteMap[7] = scared3;
        moodSpriteMap[8] = scared4;
        moodSpriteMap[9] = supprised;
        moodSpriteMap[10] = confused;
        moodSpriteMap[11] = crying;
        moodSpriteMap[12] = disgusted;
        moodSpriteMap[13] = eyesClosed;
        moodSpriteMap[14] = eyeClosed;
        moodSpriteMap[15] = happy;
        moodSpriteMap[16] = happy2;
        moodSpriteMap[17] = inLove;
    }
    private void Start()
    {
        InitializeSpriteMap();
        soldierMood = 1;
        RefreshSoldierSprite();
    }
    public void RefreshSoldierSprite()
    {
        spriteRend.sprite = moodSpriteMap[soldierMood];
    }
    void GameAdvancement(int level)
    {
        if (level > 1 && level < 5)
        {
            ChangeFace(15);
        }
        if (level >= 5 && level < 10)
        {
            ChangeFace(16);
        }
        if (level >= 10 && level < 20)
        {
            ChangeFace(17);
        }
    }
    void CityDestroyed(int cityCount)
    {
        switch (cityCount)
        {
            case 5:
                ChangeFace(4);
                break;
            case 4:
                ChangeFace(5);
                break;
            case 3:
                ChangeFace(6);
                break;
            case 2:
                ChangeFace(7);
                break;
            case 1:
                ChangeFace(8);
                break;
            case 0:
                ChangeFace(11);
                break;

            default:
                ChangeFace(0);
                break;
        }
    }

    void ChangeFace(int soldierMood)
    {
        this.soldierMood = soldierMood;
        RefreshSoldierSprite();
    }
}
        
    


