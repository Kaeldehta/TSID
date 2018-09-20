using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectile : MonoBehaviour
{
    [SerializeField]
    private int subProjectileCount = 0;
    
    public int SubProjectileCount
    {
        get
        {
            return subProjectileCount;
        }
    }

    public void AddSubProjectiles(int count)
    {
        subProjectileCount += count;
    }
}
