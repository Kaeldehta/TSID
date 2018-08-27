using UnityEngine;

public class HealthPackModuleFunctionality : MonoBehaviour, IModule
{
    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Health>().ChangeMaxHealthByAmount(30);
        target.GetComponent<Health>().ChangeHealthByAmount(200);
    }
}
