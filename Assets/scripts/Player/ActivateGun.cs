using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGun : MonoBehaviour
{
    class Gun
    {
        public delegate bool ActivationPredicate();
        private GameObject gun;
        private ActivationPredicate activationPredicate;
        public Gun(GameObject gun, ActivationPredicate activationPredicate)
        {
            this.gun = gun;
            this.activationPredicate = activationPredicate;
        }
        public bool UpdateActivationState(bool hasActiveGun)
        {
            if (this.activationPredicate() && !hasActiveGun)
            {
                gun.SetActive(true);
                return true;
            }
            else
            {
                gun.SetActive(false);
                return false;
            }
        }
    }
    [SerializeField] GameObject leftGun;
    [SerializeField] GameObject centerGun;
    [SerializeField] GameObject rightGun;
    private List<Gun> guns;
    void Start()
    {
        guns = new List<Gun>{
            new Gun(leftGun, () => Input.GetKey(KeyCode.A)),
            new Gun(rightGun, () => Input.GetKey(KeyCode.D)),
            new Gun(centerGun, () => true)
        };
    }

    void Update()
    {
        bool hasActiveGun = false;
        foreach (Gun gun in guns)
        {
            bool activated = gun.UpdateActivationState(hasActiveGun);
            if (activated)
            {
                hasActiveGun = true;
            }
        }
    }
}