using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeScreen : MonoBehaviour
{

    public int cityLocationCount;
    [SerializeField]
    float shakeDuration = 0.5f;
    [SerializeField]
    bool isShaking = false;
    [SerializeField]
    float shakeAmmount = 0.5f;
    [SerializeField]
    float decreaseFactor = 1.0f;
    Vector3 initialCameraPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initialCameraPosition = Camera.main.transform.localPosition;
        cityLocationCount = FindObjectOfType<GameManager>().startingCityPoints;
    }
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().cityPointsRemaining += Shake;
    }
    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>() != null)
        {
            FindObjectOfType<GameManager>().cityPointsRemaining -= Shake;
        }

    }
    private void Update()
    {
        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                Camera.main.transform.localPosition += Random.insideUnitSphere * shakeAmmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
        }
    }
    void Shake(int cityLocationsRemaining)
    {
        if(cityLocationsRemaining< cityLocationCount)
        {
            isShaking = true;
            StartCoroutine(Shaking());
            cityLocationCount--;
        } 
    }
    IEnumerator Shaking()
    {
        yield return new WaitForSeconds(0.5f);
        shakeDuration = 0.5f;
        isShaking = false;
        if (Camera.main.transform.localPosition != initialCameraPosition)
        {
            Camera.main.transform.localPosition = initialCameraPosition;
        }
    }
}
