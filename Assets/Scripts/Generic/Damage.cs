using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private float baseDamage = 5f;
    [SerializeField]
    private float damageIncrease = 0f;
    [SerializeField]
    private float damageMultiplier = 1f;

    public float RealDamage
    {
        get
        {
            return (baseDamage + baseDamage * damageIncrease) * damageMultiplier;
        }
    }

    public static event Action<GameObject, GameObject, float> OnDamageApplied = delegate { };

    public void ApplyDamage(GameObject target, float resistance)
    {
        float resistedDamage = RealDamage - RealDamage * resistance;
        float damageDone = Mathf.Abs(target.GetComponent<Health>().ChangeHealthByAmount(-resistedDamage));
        OnDamageApplied(gameObject, target, damageDone);
    }

    public void AddFlatDamage(float amount)
    {
        baseDamage += amount;
    }

    public void AddDamageIncrease(float increase)
    {
        damageIncrease += increase;
    }

    public void MultiplyDamage(float multiplier)
    {
        damageMultiplier *= multiplier;
    }
}
