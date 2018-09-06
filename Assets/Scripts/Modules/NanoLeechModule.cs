using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoLeechModule : MonoBehaviour, IModule
{
    [SerializeField]
    private float leechPercentagePerModule = 0.05f;

    public void AddModuleFunctionality(GameObject target)
    {
        target.AddComponent<Leech>();
        target.GetComponent<Leech>().ChangeLeechPercentageByAmount(leechPercentagePerModule);
        target.GetComponent<Weapon>().Projectile.transform.Find("NanoLeechGFX").gameObject.SetActive(true);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Leech>().ChangeLeechPercentageByAmount(leechPercentagePerModule);
    }
}
