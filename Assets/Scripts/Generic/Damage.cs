using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private float damage;
    
    public static event Action<GameObject, GameObject, float> OnDamageApplied = delegate { };

    public void ApplyDamage(GameObject target, float resistance)
    {
        float resistedDamage = damage - damage * resistance;
        float damageDone = Mathf.Abs(target.GetComponent<Health>().ChangeHealthByAmount(-resistedDamage));
        OnDamageApplied(gameObject, target, damageDone);
    }
}
