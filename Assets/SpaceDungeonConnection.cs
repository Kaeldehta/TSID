using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDungeonConnection
{
    private SpaceDungeon dungeon1;
    private SpaceDungeon dungeon2;

    public SpaceDungeon Dungeon1 { get => dungeon1; }
    public SpaceDungeon Dungeon2 { get => dungeon2; }

    public SpaceDungeonConnection(SpaceDungeon _dungeon1, SpaceDungeon _dungeon2)
    {
        dungeon1 = _dungeon1;
        dungeon2 = _dungeon2;
    }

    public bool IsDungeonPartOfConnection(SpaceDungeon d)
    {
        if(d == dungeon1 || d == dungeon2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DoesAlreadyExist(List<SpaceDungeonConnection> connections)
    {
        foreach(var c in connections)
        {
            if(c == this)
            {
                return true;
            }
        }
        return false;
    }
}
