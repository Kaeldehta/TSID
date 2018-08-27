using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerWeaponController : MonoBehaviour
{
    Weapon weapon;

    void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.ToggleShooting();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            weapon.ToggleShooting();
        }
    }
}
