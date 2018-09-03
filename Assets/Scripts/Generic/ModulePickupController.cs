using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModuleInventory))]
public class ModulePickupController : MonoBehaviour
{

    ModuleInventory inventory;

    void Start()
    {
        inventory = GetComponent<ModuleInventory>();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<IModule>() != null)
        {
            inventory.AddModuleToInventory(col.gameObject);
            col.collider.gameObject.transform.parent = gameObject.transform;
            col.collider.gameObject.SetActive(false);
        }
        
    }
}
