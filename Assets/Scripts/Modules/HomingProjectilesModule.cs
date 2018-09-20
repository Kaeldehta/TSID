using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectilesModule : MonoBehaviour, IModule
{
    [SerializeField]
    private float homingChancePerModule = 0.03f;

    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().Projectile.AddComponent<HomingProjectile>();
        target.GetComponent<Weapon>().Projectile.GetComponent<HomingProjectile>().AddHomingChance(homingChancePerModule);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().Projectile.GetComponent<HomingProjectile>().AddHomingChance(homingChancePerModule);
    }
}
