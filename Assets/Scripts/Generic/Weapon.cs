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
    private int projectilesPerShot = 1;

    [SerializeField]
    private Vector2 spawnOffset;

    public bool IsShooting { get; set; } = false;

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
            if (IsShooting)
            {
                Shoot();
            }

            shootingCountdown += 1 / shotsPerSecond;
        }

        shootingCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        
        
        float angle = Vector3.Angle(transform.up, movement.MoveDirection);

        float currentSpeed = (movement.MoveDirection * movement.MaxSpeed).magnitude;
        
        float projSpeedChange = Mathf.Cos(angle * Mathf.Deg2Rad) * currentSpeed;
        projSpeedChange /= GetComponent<Movement>().MaxSpeed * 2;
        float angleRange = (projectilesPerShot - 1) * 10;

        float lowest = -angleRange / 2;

        for(int i = 0; i < projectilesPerShot; i++)
        {
            float rotateAngle = lowest + i * 10;
            Vector3 newUp = Vector3.RotateTowards(transform.up, transform.right, rotateAngle * Mathf.Deg2Rad, 0);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, newUp);
            GameObject spawnedProj = Instantiate(Projectile, transform.position + transform.up * spawnOffset.y + transform.right * spawnOffset.x, rotation);
            spawnedProj.GetComponent<Movement>().AddSpeedIncrease(projSpeedChange);
            spawnedProj.GetComponent<Origin>().OriginGameObject = gameObject;
            spawnedProj.name = gameObject.name + "'s Projectile";
            spawnedProj.SetActive(true);
        }
        

    }

    public void ToggleShooting()
    {
        IsShooting = !IsShooting;
    }
}
