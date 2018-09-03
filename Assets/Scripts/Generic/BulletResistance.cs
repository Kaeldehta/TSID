using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletResistance : MonoBehaviour
{

    [SerializeField]
    private float bulletResistance = 0f;

    public void ChangeBulletResistanceByAmount(float amount)
    {
        bulletResistance += amount;
    }

    public float GetBulletResistance() => bulletResistance;
}
