using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterModule : MonoBehaviour, IModule
{
    [SerializeField]
    private float flatSpeedPerModule = 30;

    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Movement>().AddFlatSpeed(3);
        target.GetComponent<Weapon>().Projectile.GetComponent<Movement>().AddFlatSpeed(3);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Movement>().AddFlatSpeed(3);
        target.GetComponent<Weapon>().Projectile.GetComponent<Movement>().AddFlatSpeed(3);
    }
}
