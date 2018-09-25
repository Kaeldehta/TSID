using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab = null;

    public static event Action<GameObject> OnAnyProjectileShot = delegate { };
    public GameObject Projectile { get; private set; }

    Movement movement;
    
    public Stat ShotsPerSecond;

    [SerializeField]
    private int projectilesPerShot = 0;

    [SerializeField]
    private Vector2 spawnOffset = Vector2.zero;

    public bool IsShooting { get; set; } = false;

    float shootingCountdown;

    private float angleSpread = 5;

    void Start()
    {
        shootingCountdown = 0;
        movement = GetComponent<Movement>();
    }

    public void InstantiateProjectile(float damage, float speed)
    {
        Projectile = Instantiate(projectilePrefab, transform);
        Projectile.name = "Projectile";
        Projectile.GetComponent<Origin>().OriginGameObject = gameObject;
        Projectile.GetComponent<Movement>().MaxSpeed = new Stat(speed);
        Projectile.GetComponent<Damage>().RealDamage = new Stat(damage);
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

            shootingCountdown += 1 / ShotsPerSecond.StatValue;
        }

        shootingCountdown -= Time.deltaTime;
    }

    public void AddProjectilesPerShot(int count)
    {
        projectilesPerShot += count;
    }

    private void Shoot()
    {
        
        float angle = Vector3.Angle(transform.up, movement.MoveDirection);

        float currentSpeed = (movement.MoveDirection * movement.MaxSpeed.StatValue).magnitude;
        
        float projSpeedChange = Mathf.Cos(angle * Mathf.Deg2Rad) * currentSpeed;
        projSpeedChange /= GetComponent<Movement>().MaxSpeed.StatValue * 2;
        float angleRange = (projectilesPerShot - 1) * angleSpread;

        float lowest = -angleRange / 2;

        for(int i = 0; i < projectilesPerShot; i++)
        {
            float rotateAngle = lowest + i * angleSpread;
            Vector3 newUp = Vector3.RotateTowards(transform.up, transform.right, rotateAngle * Mathf.Deg2Rad, 0);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, newUp);
            GameObject spawnedProj = Instantiate(Projectile, transform.position + transform.up * spawnOffset.y + transform.right * spawnOffset.x, rotation);
            spawnedProj.GetComponent<Movement>().MaxSpeed.AddIncrease(projSpeedChange);
            //spawnedProj.GetComponent<Origin>().OriginGameObject = gameObject;
            spawnedProj.name = gameObject.name + "'s Projectile";
            spawnedProj.SetActive(true);
            OnAnyProjectileShot(spawnedProj);
            
        }
        
    }

    public void ToggleShooting()
    {
        IsShooting = !IsShooting;
    }

}
