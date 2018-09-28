using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField]
    GameObject dungeonPrefab;
    [SerializeField]
    GameObject currentDungeonIndicator;
    private void OnEnable()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject != gameObject)
                Destroy(child.gameObject);
        }

        foreach (var d in LevelGenerator.Level.Dungeons)
        {
            var dGO = Instantiate(dungeonPrefab, transform);
            Vector3 pos = new Vector3(d.MapPosition.x * 50, d.MapPosition.y * 50);
            Vector3 offset = new Vector3(200, 0);
            dGO.transform.position += offset + pos;

            if(d.MapPosition.x == 0)
            {
                var cur = Instantiate(currentDungeonIndicator, transform);
                cur.transform.position = dGO.transform.position;
            }
        }

        
        


    }
}
