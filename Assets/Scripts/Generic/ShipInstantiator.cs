using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInstantiator : MonoBehaviour
{
    
    [SerializeField]
    private ShipBaseStatsContainer container = null;
    void Start()
    {
        GetComponent<Health>().MaxHealth = new Stat(container.baseHealth);
        GetComponent<Movement>().MaxSpeed = new Stat(container.baseSpeed);
        GetComponent<Weapon>().ShotsPerSecond = new Stat(container.baseShotsPerSecond);
        GetComponent<Weapon>().AddProjectilesPerShot(container.baseProjectilesPerShot);
        GetComponent<Weapon>().InstantiateProjectile(container.baseDamage, container.baseProjectileSpeed);
        Debug.Log("Successfully instantiated " + gameObject.name);
    }
    
}
