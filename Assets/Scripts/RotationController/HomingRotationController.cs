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
    List<GameObject> blackList;

    [SerializeField]
    List<GameObject> closeRangeEntities;

    void Start()
    {
        rotation = GetComponent<Rotation>();
        rotation.SetRotationSpeed(homingSpeed);
        if(closeRangeEntities == null)
        {
            closeRangeEntities = new List<GameObject>();
        }
        if(blackList == null)
        {
            blackList = new List<GameObject>();
        }
    }

    public void BlackList(GameObject gameObject)
    {
        blackList.Add(gameObject);
    }
    
    
    void UpdateCloseRangeEntities()
    {
        closeRangeEntities.RemoveAll(item => Vector3.Distance(item.transform.position, transform.position) > homingRadius);
        closeRangeEntities.RemoveAll(item => blackList.Contains(item) == true);

        var allEntities = GameObject.FindGameObjectsWithTag("Entity");
        List<GameObject> insideRadius = new List<GameObject>();
        insideRadius.AddRange(allEntities);


        insideRadius.RemoveAll(item => blackList.Contains(item) == true);
        insideRadius.RemoveAll(item => Vector3.Distance(item.transform.position, transform.position) > homingRadius);
        insideRadius.RemoveAll(item => closeRangeEntities.Contains(item) == true);

        closeRangeEntities.AddRange(insideRadius);
        
    }
    
    void Update()
    {
        UpdateCloseRangeEntities();
        
        GameObject closestInRadius = null;
        float mag = Mathf.Infinity;
        foreach(var enemy in closeRangeEntities)
        {
            float r = Vector3.Distance(enemy.transform.position, transform.position);
            if ( r < mag)
            {
                closestInRadius = enemy;
            }
        }
        
        if(closestInRadius != null)
        {
            rotation.SetNewRotation(Quaternion.LookRotation(Vector3.forward, closestInRadius.transform.position - transform.position));
        }
        
    }

}
