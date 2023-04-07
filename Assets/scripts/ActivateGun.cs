using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGun : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public int gunNumber;

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            gunNumber = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gunNumber = 2;
        }
        else
        {
            gunNumber = 1;
        }
        ChooseGun();
    }


    public void ChooseGun()
    {
        switch (gunNumber)
        {

            case 0:
                gun1.SetActive(true);
                gun2.SetActive(false);
                gun3.SetActive(false);


                break;
            case 1:
                gun1.SetActive(false);
                gun2.SetActive(true);
                gun3.SetActive(false);

                break;
            case 2:
                gun1.SetActive(false);
                gun2.SetActive(false);
                gun3.SetActive(true);

                break;

            default:
                Debug.Log("Error");
                break;
        }
    }
}
