using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceDungeon
{
    private Scene dungeonScene;
    private int id;

    private static int nextId = 0;

    public SpaceDungeon()
    {
        dungeonScene = SceneManager.CreateScene("dungeon" + nextId);
        id = nextId;
        nextId++;
    }

    public override string ToString()
    {
        return id.ToString();
    }

    public static SpaceDungeonConnection operator +(SpaceDungeon d1, SpaceDungeon d2)
    {
        return new SpaceDungeonConnection(d1, d2);
        
    }

    public bool HasConnection(List<SpaceDungeonConnection> connections)
    {
        foreach(var c in connections)
        {
            if (c.IsDungeonPartOfConnection(this))
            {
                return true;
            }
        }
        return false;
    }

    public List<SpaceDungeonConnection> GetAllConnections(List<SpaceDungeonConnection> connections)
    {
        List<SpaceDungeonConnection> con = new List<SpaceDungeonConnection>();
        foreach (var c in connections)
        {
            if (c.Dungeon1 == this)
            {
                con.Add(c);
            }
        }

        return con;
    }
    
}
