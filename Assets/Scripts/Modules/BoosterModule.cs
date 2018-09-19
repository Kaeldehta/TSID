using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterModule : MonoBehaviour, IModule
{
    [SerializeField]
    private float flatSpeedPerModule = 3f;

    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Movement>().AddFlatSpeed(flatSpeedPerModule);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Movement>().AddFlatSpeed(flatSpeedPerModule);
    }
}
