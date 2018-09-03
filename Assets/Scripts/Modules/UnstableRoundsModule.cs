using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableRoundsModule : MonoBehaviour, IModule
{
    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().Projectile.AddComponent<UnstableProjectiles>();
        
        target.GetComponent<Weapon>().Projectile.GetComponent<Decay>().DecayTime = 0.2f;
    }
}
