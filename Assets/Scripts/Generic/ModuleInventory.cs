using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleInventory : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> moduleInventory;

    int oldCount;

    void Start()
    {
        oldCount = moduleInventory.Count;
    }

    void Update()
    {
        for (int i = oldCount; i < moduleInventory.Count; i++)
        {
            moduleInventory[i].GetComponent<IModule>().AddModuleFunctionality(gameObject);
            oldCount++;
        }
    }

    public void AddModuleToInventory(GameObject module)
    {
        moduleInventory.Add(module);
    }
}
