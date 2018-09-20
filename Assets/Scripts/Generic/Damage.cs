using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Stat RealDamage;
    
    public static event Action<GameObject, GameObject, float> OnAnyDamageApplied = delegate { };

    public void ApplyDamage(GameObject target, float resistance)
    {
        float resistedDamage = RealDamage.StatValue - RealDamage.StatValue * resistance;
        float damageDone = Mathf.Abs(target.GetComponent<Health>().ChangeHealthByAmount(-resistedDamage));
        OnAnyDamageApplied(gameObject, target, damageDone);
    }
    
}
