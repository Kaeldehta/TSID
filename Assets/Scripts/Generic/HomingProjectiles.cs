using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectiles : MonoBehaviour
{
    [SerializeField]
    private float homingChance = 0f;
    void Start()
    {
        Weapon.OnAnyProjectileShot += HandleHoming;
    }

    void HandleHoming(GameObject projectile)
    {
        if(projectile.GetComponent<Origin>().OriginGameObject == gameObject)
        {
            float r = Random.value;
            if (r <= homingChance)
            {
                var movementController = (Component)projectile.GetComponent<IMovementController>();
                Destroy(movementController);
                projectile.AddComponent<HomingMovementController>();
            }
        }
    }

    public void AddHomingChance(float chance)
    {
        homingChance += chance;
    }
}
