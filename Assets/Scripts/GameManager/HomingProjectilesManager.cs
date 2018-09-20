using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectilesManager : MonoBehaviour
{
    
    void Start()
    {
        Weapon.OnAnyProjectileShot += HandleHoming;
        ProjectileCollision.OnAnyProjectileHit += HandleHomingCollision;
    }

    private void HandleHomingCollision(GameObject projectile, GameObject hitObject, Vector2 collisionPoint)
    {
        if(projectile.GetComponent<HomingRotationController>() != null)
        {
            projectile.GetComponent<HomingRotationController>().BlackList(hitObject);
        }
    }

    void HandleHoming(GameObject projectile)
    {
        if(projectile.GetComponent<HomingProjectile>() != null)
        {
            float r = UnityEngine.Random.value;
            if (r <= projectile.GetComponent<HomingProjectile>().HomingChance)
            {
                projectile.AddComponent<HomingRotationController>();
            }
        }
    }
    
    
}
