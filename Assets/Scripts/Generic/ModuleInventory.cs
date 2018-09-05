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
            bool isFirst = true;
            for(int j = 0; j < i; j++)
            {
                if(moduleInventory[i].GetComponent<IModule>().GetType() == moduleInventory[j].GetComponent<IModule>().GetType())
                {
                    isFirst = false;
                    break;
                }
            }
            if (isFirst)
            {
                moduleInventory[i].GetComponent<IModule>().AddModuleFunctionality(transform.parent.gameObject);
            }
            else
            {
                moduleInventory[i].GetComponent<IModule>().UpgradeModuleFunctionality(transform.parent.gameObject);
            }
            oldCount++;
        }
    }
    
    public void AddModuleToInventory(GameObject module)
    {
        moduleInventory.Add(module);
    }
}
