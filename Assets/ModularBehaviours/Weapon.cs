using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    public Movement ProjMovementComp
    {
        get
        {
            return projectilePrefab.GetComponent<Movement>();
        }
    }

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
        GameObject spawnedProj = Instantiate(projectilePrefab, transform.position + transform.up * spawnOffset.y + transform.right * spawnOffset.x, transform.rotation);
        spawnedProj.GetComponent<Damage>().Source = gameObject;

        float angle = Vector3.Angle(transform.up, movement.MoveDirection);

        float currentSpeed = (movement.MoveDirection * movement.Speed).magnitude;
        
        float projSpeedChange = Mathf.Cos(angle * Mathf.Deg2Rad) * currentSpeed;
        
        spawnedProj.GetComponent<Movement>().ChangeSpeedByAmount(projSpeedChange);

    }

    public void ToggleShooting()
    {
        isShooting = !isShooting;
    }
}
