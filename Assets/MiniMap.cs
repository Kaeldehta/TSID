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
        
        foreach (var d in LevelGenerator.Level.Dungeons)
        {
            var dGO = Instantiate(dungeonPrefab, transform);
            Vector3 pos = new Vector3(d.MapPosition.x * 50, d.MapPosition.y * 50);
            Vector3 offset = new Vector3(200, 0);
            dGO.transform.position += offset + pos;

            if(d.MapPosition.x == 0 && d.MapPosition.y == 0)
            {
                var cur = Instantiate(currentDungeonIndicator, transform);
                cur.transform.position = dGO.transform.position;
            }
        }

        
        foreach (var c in LevelGenerator.Level.Connections)
        {
            Vector3 offset = new Vector3(200, 0);
            var pos1 = new Vector3(c.FirstDungeon.MapPosition.x * 50, c.FirstDungeon.MapPosition.y * 50) + offset;
            var pos2 = new Vector3(c.SecondDungeon.MapPosition.x * 50, c.SecondDungeon.MapPosition.y * 50) + offset;
            
            var line = Instantiate(new GameObject(), transform).AddComponent<LineRenderer>();
            line.positionCount = 2;
            line.startWidth = 5;
            line.endWidth = 5;
            line.SetPosition(0, pos1 + line.transform.position);
            line.SetPosition(1, pos2 + line.transform.position);

        }
        

    }

    private void OnDisable()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject != gameObject)
                Destroy(child.gameObject);
        }
    }

}
