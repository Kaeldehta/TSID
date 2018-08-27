using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField]
    private float damage;
    private GameObject source;

    public GameObject Source
    {
        get
        {
            return source;
        }
        set
        {
            source = value;
        }
    }

    public float ApplyDamage(GameObject target, float resistance)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            float resistedDmg = damage - damage * resistance;
            
            float damageDone = health.ChangeHealthByAmount(-resistedDmg);
            Debug.Log(target.name + " has been damaged by " + source.name + "(" + damageDone + ").");
            return damageDone;
        }
        Debug.Log("Not damagable object");
        return 0;
    }

    public float ApplyDamage(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log(target.name + " has been damaged by " + source.name);
            return health.ChangeHealthByAmount(-damage);
        }
        Debug.Log("Not damagable object");
        return 0;
    }
}
