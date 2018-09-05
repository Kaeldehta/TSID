using System;
using UnityEngine;

public abstract class Module : MonoBehaviour {

    public static event Action<GameObject> OnModuleUpdate = delegate { };

    public virtual void AddModuleFunctionality(GameObject target)
    {
        //OnModuleUpdate(target);
    }
}
