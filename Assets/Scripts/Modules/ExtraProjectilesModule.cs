using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraProjectilesModule : MonoBehaviour, IModule
{
    [SerializeField]
    private int extraProjectilesPerModule = 1;
    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().AddProjectilesPerShot(extraProjectilesPerModule);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Weapon>().AddProjectilesPerShot(extraProjectilesPerModule);
    }
    
}
