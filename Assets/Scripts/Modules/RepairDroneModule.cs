using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairDroneModule : MonoBehaviour, IModule
{
    [SerializeField]
    [Range(0, 1f)]
    private float regenAmountPerModule = 0.01f;
    public void AddModuleFunctionality(GameObject target)
    {
        if(target.GetComponent<HealthRegen>() == null)
        {
            target.AddComponent<HealthRegen>();
        }
        
        target.GetComponent<HealthRegen>().ChangePercentRegenPerSecByAmount(regenAmountPerModule);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<HealthRegen>().ChangePercentRegenPerSecByAmount(regenAmountPerModule);
    }
    
}
