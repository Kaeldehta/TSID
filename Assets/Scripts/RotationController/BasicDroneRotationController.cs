using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDroneRotationController : MonoBehaviour
{
    GameObject player;
    Rotation rotation;

    void Start()
    {
        rotation = GetComponent<Rotation>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        rotation.SetNewRotation(Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position));
    }
}
