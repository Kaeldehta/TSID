using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMovementController : MonoBehaviour, IMovementController
{
    Movement movement;
    [SerializeField]
    private float homingRadius = 10f;
    [SerializeField]
    private float homingSpeed = 10f;

    void Start()
    {
        movement = GetComponent<Movement>();
    }
    
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Entity");
        GameObject closestInRadius = null;
        float mag = Mathf.Infinity;
        foreach(var enemy in enemies)
        {
            float r = (enemy.transform.position - transform.position).magnitude;
            if ( r < mag && r < homingRadius)
            {
                closestInRadius = enemy;
            }
        }
        if(closestInRadius != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, closestInRadius.transform.position - transform.position), Time.deltaTime * homingSpeed /*/ (closestInRadius.transform.position - transform.position).magnitude*/);
        }
        
        movement.MoveDirection = transform.up;
    }

}
