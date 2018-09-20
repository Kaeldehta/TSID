using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingProjectilesManager : MonoBehaviour
{
    private void Start()
    {
        ProjectileCollision.OnAnyProjectileHit += HandlePiercing;
    }

    private void HandlePiercing(GameObject projectile, GameObject hitObject, Vector2 collisionPoint)
    {
        if(projectile.GetComponent<PiercingProjectile>() != null)
        {
            float r = Random.value;
            if (r <= projectile.GetComponent<PiercingProjectile>().PiercingChance)
            {
                projectile.GetComponent<ProjectileCollision>().SetDestroyOnCollision(false);
                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), hitObject.GetComponent<Collider2D>());
            }
        }
    }
}
