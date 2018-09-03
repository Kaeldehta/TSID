using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour
{

    [SerializeField]
    private float leechPercentage = 0.02f;
    Health health;
    void Start()
    {
        Damage.OnDamageApplied += LeechLife;
        health = GetComponent<Health>();
    }

    void LeechLife(GameObject source, GameObject target, float damageDone)
    {
        if(source.GetComponent<Origin>().OriginGameObject == gameObject && health.gameObject.CompareTag("Entity"))
        {
            float leechedLife = damageDone * leechPercentage;
            health.ChangeHealthByAmount(leechedLife);
        }
    }
}
