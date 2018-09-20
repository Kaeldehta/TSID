using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]
    float baseStat;
    [SerializeField]
    float increase;
    [SerializeField]
    List<float> multipliers;

    public Stat(float _baseStat)
    {
        baseStat = _baseStat;
        increase = 0;
        multipliers = new List<float>();
    }

    public float StatValue
    {
        get
        {
            return (baseStat + baseStat * increase) * endMultiplier;
        }
    }

    float endMultiplier
    {
        get
        {
            float eM = 1;
            foreach(var m in multipliers)
            {
                eM *= m;
            }
            return eM;
        }
    }

    public void AddFlat(float amount)
    {
        baseStat += amount;
    }

    public void AddIncrease(float increase)
    {
        increase += increase;
    }


    public void AddMultiplier(float multiplier)
    {
        multipliers.Add(multiplier);
    }
}
