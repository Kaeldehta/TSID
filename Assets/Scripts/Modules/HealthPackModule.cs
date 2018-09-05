using UnityEngine;

public class HealthPackModule : MonoBehaviour, IModule
{
    [SerializeField]
    private float flatHealthPerModule = 30;

    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Health>().AddFlatHealth(flatHealthPerModule);
    }

    public void UpgradeModuleFunctionality(GameObject target)
    {
        target.GetComponent<Health>().AddFlatHealth(flatHealthPerModule);
    }
}
