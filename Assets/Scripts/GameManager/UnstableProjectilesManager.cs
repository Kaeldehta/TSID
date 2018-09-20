using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectilesManager : MonoBehaviour
{

    void Start()
    {
        Decay.OnAnyDecayed += SpawnSubProjectiles;
    }

    void SpawnSubProjectiles(GameObject projectile)
    {
        if (projectile.GetComponent<UnstableProjectile>() != null)
        {

            for (int i = 0; i < projectile.GetComponent<UnstableProjectile>().SubProjectileCount; i++)
            {
                GameObject spawnedSubProjectile = Instantiate(projectile);
                Vector3 up = projectile.transform.up;
                float newAngle = Random.Range(-45, 45);
                up = Vector3.RotateTowards(up, projectile.transform.right, newAngle * Mathf.Deg2Rad, 0);
                spawnedSubProjectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, up);
                spawnedSubProjectile.transform.localScale *= 0.7f;
                Destroy(spawnedSubProjectile.GetComponent<UnstableProjectile>());
                spawnedSubProjectile.GetComponent<Decay>().DecayRange = 50f;
                spawnedSubProjectile.GetComponent<Damage>().RealDamage.AddMultiplier(0.5f);
                spawnedSubProjectile.name = "Sub Projectile";
                spawnedSubProjectile.SetActive(true);
            }
        }

    }


}