using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayer
{
    private List<SpaceDungeon> dungeons = new List<SpaceDungeon>();

    public List<SpaceDungeon> Dungeons
    {
        get
        {
            return dungeons;
        }
    }

    public LevelLayer(int maxNumberOfDungeons, int numberOfDungeons)
    {
        for (int i = 0; i < maxNumberOfDungeons; i++)
        {
            dungeons.Add(null);
        }
        int addedDungeons = 0;
        while (addedDungeons < numberOfDungeons)
        {
            int posInLayer = Random.Range(0, maxNumberOfDungeons);
            if (dungeons[posInLayer] == null)
            {
                dungeons[posInLayer] = new SpaceDungeon();
                addedDungeons++;
            }
        }

    }

    public static List<SpaceDungeonConnection> operator +(LevelLayer l1, LevelLayer l2)
    {
        List<SpaceDungeonConnection> connections = new List<SpaceDungeonConnection>();
        
        foreach (var d in l1.dungeons)
        {
            if (d != null && !d.HasConnection(connections))
            {
                List<SpaceDungeon> possibleConnectionPartners = new List<SpaceDungeon>();
                
                foreach(var cP in l2.dungeons)
                {
                    if (cP != null)
                        possibleConnectionPartners.Add(cP);
                }
                Debug.Log(Random.seed);
                int howManyConnections = Random.Range(1, 3);
                int connectionsCreated = 0;
                while (connectionsCreated < howManyConnections)
                {
                    int randomCPartner = Random.Range(0, possibleConnectionPartners.Count);
                    var c = d + possibleConnectionPartners[randomCPartner];
                    if (!c.DoesAlreadyExist(connections))
                    {
                        connections.Add(c);
                        connectionsCreated++;
                        possibleConnectionPartners.Remove(possibleConnectionPartners[randomCPartner]);
                    }
                }

            }
        }
        
        return connections;
    }

}
