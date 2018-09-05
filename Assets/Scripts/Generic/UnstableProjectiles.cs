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
        if(projectile.GetComponent<Origin>().OriginGameObject == gameObject && !projectile.CompareTag("Sub Projectile"))
        {
            
            for (int i = 0; i < subProjectileCount; i++)
            {
                GameObject spawnedSubProjectile = Instantiate(projectile);
                spawnedSubProjectile.tag = "Sub Projectile";
                spawnedSubProjectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, Random.insideUnitCircle);
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