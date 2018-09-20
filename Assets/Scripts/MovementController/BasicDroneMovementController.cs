using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDroneMovementController : MonoBehaviour
{
    GameObject player;
    Movement movement;

    Vector3 targetPoint;
    void Start()
    {
        movement = GetComponent<Movement>();
        player = GameObject.FindGameObjectWithTag("Player");
        targetPoint = GetNewTargetPoint();
        movement.MoveDirection = (targetPoint - transform.position).normalized;
        Debug.Log("Test");
    }

    Vector3 GetNewTargetPoint()
    {
        Vector3 point = Random.insideUnitCircle.normalized;
        point *= Random.Range(10, 30);

        point += player.transform.position;

        Debug.DrawLine(player.transform.position, point, Color.green, 1);
        

        return point;

    }

    private void Update()
    {
        if ((targetPoint - transform.position).magnitude < 1f)
        {
            targetPoint = GetNewTargetPoint();
            movement.MoveDirection = (targetPoint - transform.position).normalized;
        }

        Debug.DrawLine(transform.position, targetPoint, Color.red, 1);
    }
}
