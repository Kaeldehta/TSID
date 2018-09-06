using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectiles : MonoBehaviour
{
    [SerializeField]
    private int subProjectileCount = 0;

    void Start()
    {
        Decay.OnAnyDecayed += SpawnSubProjectiles;
    }

    void SpawnSubProjectiles(GameObject projectile)
    {
        if (projectile.GetComponent<Origin>().OriginGameObject == gameObject && !projectile.CompareTag("Sub Projectile"))
        {

            for (int i = 0; i < subProjectileCount; i++)
            {
                GameObject spawnedSubProjectile = Instantiate(projectile);
                spawnedSubProjectile.tag = "Sub Projectile";
                Vector3 up = projectile.transform.up;
                float newAngle = Random.Range(-45, 45);
                up = Vector3.RotateTowards(up, projectile.transform.right, newAngle * Mathf.Deg2Rad, 0);
                //Debug.DrawRay(projectile.transform.position, up * 5, Color.red, 1);
                spawnedSubProjectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, up);
                spawnedSubProjectile.transform.localScale *= 0.7f;
                spawnedSubProjectile.GetComponent<Decay>().DecayRange = 50f;
                spawnedSubProjectile.GetComponent<Movement>().AddSpeedIncrease(1);
                spawnedSubProjectile.name = "Sub Projectile";
                spawnedSubProjectile.SetActive(true);
            }
        }

    }


    public void AddSubProjectiles(int count)
    {
        subProjectileCount += count;
    }
}