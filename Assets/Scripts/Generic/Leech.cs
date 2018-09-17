using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour
{

    [SerializeField]
    [Range(0, 1)]
    private float leechPercentage = 0f;
    Health health;
    void Start()
    {
        Damage.OnAnyDamageApplied += LeechLife;
        health = GetComponent<Health>();
    }

    void LeechLife(GameObject source, GameObject target, float damageDone)
    {
        if (source.GetComponent<Origin>().OriginGameObject == gameObject && target.CompareTag("Entity"))
        {
            float leechedLife = damageDone * leechPercentage;
            Debug.Log(leechedLife);
            health.ChangeHealthByAmount(leechedLife);
        }
    }

    public void ChangeLeechPercentageByAmount(float amount)
    {
        leechPercentage += amount;
    }
}
