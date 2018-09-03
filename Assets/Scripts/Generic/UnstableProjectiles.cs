using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableProjectiles : MonoBehaviour
{
    [SerializeField]
    private int subProjectileCount = 3;

    private GameObject subProjectile;

    void Start()
    {   
        GetComponent<Decay>().OnDecayed += SpawnSubProjectiles;
    }

    void SpawnSubProjectiles()
    {
        subProjectile = Instantiate(gameObject, transform);
        Destroy(subProjectile.GetComponent<UnstableProjectiles>());

        for (int i = 0; i < subProjectileCount; i++)
        {
            Vector2 lookDirection = Random.insideUnitCircle;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
            var subProj = Instantiate(subProjectile, transform.position, lookRotation);
            subProj.GetComponent<Origin>().OriginGameObject = GetComponent<Origin>().OriginGameObject;
            subProj.GetComponent<Decay>().DecayTime = 5;
            subProj.SetActive(true);
        }
    }
}
