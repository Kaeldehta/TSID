using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulePickupController : MonoBehaviour
{

    ModuleInventory inventory;

    void Start()
    {
        inventory = GetComponentInChildren<ModuleInventory>();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<IModule>() != null)
        {
            inventory.AddModuleToInventory(col.gameObject);
            col.collider.gameObject.transform.parent = inventory.gameObject.transform;
            col.collider.gameObject.SetActive(false);
        }
        
    }
}
