using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestSubject: MonoBehaviour
{
   

    public delegate void OnRandomNumberGenerated(int number);
    public event OnRandomNumberGenerated ParseInNumber;

   IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            WriteLine();
            
        }
    }
    
    void WriteLine()
    {
        ParseInNumber.Invoke(Random.Range(1,10)); 
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
