using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectilesModule : MonoBehaviour, IModule
{
    [SerializeField]
    private int subProjectilesPerModule = 2;
    [SerializeField]
    private float damageMultiplierPerModule = 0.8f;
    public void AddModuleFunctionality(GameObject target)
    {
        target.AddComponent<UnstableProjectiles>();
        target.GetComponent<UnstableProjectiles>().AddSubProjectiles(subProjectilesPerModule);
        target.GetComponent<Weapon>().Projectile.GetComponent<Decay>().DecayRange = 5f;
        target.GetComponent<Weapon>().Projectile.GetComponent<Damage>().MultiplyDamage(damageMultiplierPerModule);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<UnstableProjectiles>().AddSubProjectiles(subProjectilesPerModule);
        target.GetComponent<Weapon>().Projectile.GetComponent<Damage>().MultiplyDamage(damageMultiplierPerModule);
    }
}
