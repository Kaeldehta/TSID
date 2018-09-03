using UnityEngine;

public class HealthPackModuleFunctionality : MonoBehaviour, IModule
{
    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Health>().AddFlatHealth(30);
    }
}
