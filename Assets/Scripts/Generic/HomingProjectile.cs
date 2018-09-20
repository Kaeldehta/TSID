using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    [SerializeField]
    private float homingChance = 0f;

    public float HomingChance
    {
        get
        {
            if (homingChance < 0)
            {
                return 0;
            }
            else if (homingChance > 1)
            {
                return 1;
            }
            else
            {
                return homingChance;
            }
        }
    }

    public void AddHomingChance(float chance)
    {
        homingChance += chance;
    }
}
