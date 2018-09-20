using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectilesModule : MonoBehaviour, IModule
{
    [SerializeField]
    private int subProjectilesPerModule = 2;
    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().Projectile.AddComponent<UnstableProjectile>();
        target.GetComponent<Weapon>().Projectile.GetComponent<UnstableProjectile>().AddSubProjectiles(subProjectilesPerModule);
        target.GetComponent<Weapon>().Projectile.GetComponent<Decay>().DecayRange = 5f;
        //target.GetComponent<Weapon>().Projectile.GetComponent<Damage>().MultiplyDamage(damageMultiplierPerModule);
        target.GetComponent<Weapon>().Projectile.transform.Find("UnstableGFX").gameObject.SetActive(true);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().Projectile.GetComponent<UnstableProjectile>().AddSubProjectiles(subProjectilesPerModule);
        //target.GetComponent<Weapon>().Projectile.GetComponent<Damage>().MultiplyDamage(damageMultiplierPerModule);
    }
}
