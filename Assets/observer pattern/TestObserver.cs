using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        FindObjectOfType<TestSubject>().ParseInNumber += write;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void write(int number)
    {
        Debug.Log(number);
    }



}
