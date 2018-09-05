using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectilesModule : MonoBehaviour, IModule
{
    [SerializeField]
    private int subProjectilesPerModule = 2;
    public void AddModuleFunctionality(GameObject target)
    {
        target.AddComponent<UnstableProjectiles>();
        target.GetComponent<UnstableProjectiles>().AddSubProjectiles(subProjectilesPerModule);
        target.GetComponent<Weapon>().Projectile.GetComponent<Decay>().DecayTime = 0.2f;
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<UnstableProjectiles>().AddSubProjectiles(subProjectilesPerModule);
    }
}
