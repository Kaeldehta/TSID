using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingProjectile : MonoBehaviour
{
    [SerializeField]
    float piercingChance = 0f;

    public float PiercingChance
    {
        get
        {
            if (piercingChance < 0)
            {
                return 0;
            }
            else if (piercingChance > 1)
            {
                return 1;
            }
            else
            {
                return piercingChance;
            }
        }
    }

    public void AddPiercingChance(float chance)
    {
        piercingChance += chance;
    }

}
