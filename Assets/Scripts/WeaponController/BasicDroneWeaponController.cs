using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDroneWeaponController : MonoBehaviour
{
    GameObject player;
    Weapon weapon;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 30f)
        {
            weapon.IsShooting = true;
        }
        else
        {
            weapon.IsShooting = false;
        }
    }
}
