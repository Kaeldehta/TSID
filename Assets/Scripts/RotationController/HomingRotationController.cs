using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class HomingRotationController : MonoBehaviour
{
    Rotation rotation;
    [SerializeField]
    private float homingRadius = 10f;
    [SerializeField]
    private float homingSpeed = 10f;

    [SerializeField]
    List<GameObject> blackList = new List<GameObject>();

    [SerializeField]
    List<GameObject> closeRangeEntities = new List<GameObject>();

    void Start()
    {
        rotation = GetComponent<Rotation>();
        rotation.SetRotationSpeed(homingSpeed);
    }

    public void BlackList(GameObject gameObject)
    {
        blackList.Add(gameObject);
    }


    void UpdateCloseRangeEntities()
    {
        closeRangeEntities.RemoveAll(item => item == null);
        closeRangeEntities.RemoveAll(item => Vector3.Distance(item.transform.position, transform.position) > homingRadius);
        closeRangeEntities.RemoveAll(item => blackList.Contains(item));

        var allEntities = GameObject.FindGameObjectsWithTag(GetComponent<Origin>().EnemyTag);
        List<GameObject> insideRadius = new List<GameObject>();
        insideRadius.AddRange(allEntities);


        insideRadius.RemoveAll(item => blackList.Contains(item));
        insideRadius.RemoveAll(item => Vector3.Distance(item.transform.position, transform.position) > homingRadius);
        insideRadius.RemoveAll(item => closeRangeEntities.Contains(item));

        closeRangeEntities.AddRange(insideRadius);

    }

    void Update()
    {
        UpdateCloseRangeEntities();

        GameObject closestInRadius = null;
        float mag = Mathf.Infinity;
        foreach (var enemy in closeRangeEntities)
        {
            float r = Vector3.Distance(enemy.transform.position, transform.position);
            if (r < mag)
            {
                closestInRadius = enemy;
            }
        }

        if (closestInRadius != null)
        {
            rotation.SetNewRotation(Quaternion.LookRotation(Vector3.forward, closestInRadius.transform.position - transform.position));
        }

    }

}
