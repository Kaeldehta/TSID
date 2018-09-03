using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterModule : MonoBehaviour,IModule
{
    public void AddModuleFunctionality(GameObject target)
    {
        target.GetComponent<Movement>().AddFlatSpeed(3);
        target.GetComponent<Weapon>().Projectile.GetComponent<Movement>().AddFlatSpeed(3);
    }
    
}
