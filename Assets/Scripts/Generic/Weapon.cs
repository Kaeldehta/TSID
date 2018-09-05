using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    public GameObject Projectile { get; private set; }

    Movement movement;

    [SerializeField]
    private float shotsPerSecond = 2f;

    [SerializeField]
    private int projectilesPerSecond = 1;

    [SerializeField]
    private Vector2 spawnOffset;
    
    bool isShooting = false;

    float shootingCountdown;

    void Start()
    {
        shootingCountdown = 0;
        movement = GetComponent<Movement>();
        Projectile = Instantiate(projectilePrefab, transform);
        Projectile.name = "Projectile";
        Projectile.GetComponent<Origin>().OriginGameObject = gameObject;
        Projectile.SetActive(false);
    }
    
    void Update()
    {
        if (shootingCountdown <= 0)
        {
            if (isShooting)
            {
                Shoot();
            }

            shootingCountdown += 1 / shotsPerSecond;
        }

        shootingCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject spawnedProj = Instantiate(Projectile, transform.position + transform.up * spawnOffset.y + transform.right * spawnOffset.x, transform.rotation);
        
        float angle = Vector3.Angle(transform.up, movement.MoveDirection);

        float currentSpeed = (movement.MoveDirection * movement.MaxSpeed).magnitude;
        
        float projSpeedChange = Mathf.Cos(angle * Mathf.Deg2Rad) * currentSpeed;
        
        spawnedProj.GetComponent<Movement>().AddFlatSpeed(projSpeedChange);
        spawnedProj.GetComponent<Origin>().OriginGameObject = gameObject;
        spawnedProj.SetActive(true);

    }

    public void ToggleShooting()
    {
        isShooting = !isShooting;
    }
}
