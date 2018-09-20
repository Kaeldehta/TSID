using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerWeaponController : MonoBehaviour
{
    Weapon weapon;
    PlayerMovementController playerMovement;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        playerMovement = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        weapon.IsShooting = Input.GetButton("Fire1") && !playerMovement.TravelMode;
    }
}
