using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap
{
    private List<List<SpaceDungeon>> dungeons = new List<List<SpaceDungeon>>();
    private List<SpaceDungeonConnection> connections = new List<SpaceDungeonConnection>();

    private List<Position> mainPath = new List<Position>();

    public struct Position
    {
        public int layer;
        public int spot;

        public Position(List<List<SpaceDungeon>> _map, List<SpaceDungeon> _layer, SpaceDungeon _dungeon)
        {
            layer = _map.IndexOf(_layer);
            spot = _layer.IndexOf(_dungeon);
        }

        public Position(int _layer, int _spot)
        {
            layer = _layer;
            spot = _spot;
        }

    }

    public List<Vector2> DungeonVectors
    {
        get
        {
            List<Vector2> list = new List<Vector2>();
            for (int x = 0; x < dungeons.Count; x++)
            {
                for (int y = 0; y < dungeons[x].Count; y++)
                {
                    if (dungeons[x][y] != null)
                    {
                        list.Add(new Vector2(x, y));
                    }
                }
            }
            return list;
        }
    }
    
    public LevelMap(int mainPathLength)
    {
        int spawnedDungeonCount = 0;
        List<SpaceDungeon> firstLayer = new List<SpaceDungeon>();
        SpaceDungeon firstDungeon = new SpaceDungeon();
        firstLayer.Add(firstDungeon);
        dungeons.Add(firstLayer);

        Position lastDungeonPosition = new Position(dungeons, firstLayer, firstDungeon);

        while (spawnedDungeonCount < mainPathLength)
        {
            int direction = Random.Range(-1, 2);
            Debug.Log("Next Dungeon: " + direction);
            List<SpaceDungeon> nextLayer = new List<SpaceDungeon>();

            if (direction == -1 && lastDungeonPosition.spot == 0)
            {
                for (int i = 0; i < lastDungeonPosition.layer + 1; i++)
                {
                    dungeons[i].Insert(0, null);
                }
                lastDungeonPosition.spot++;
            }

            for (int i = 0; i < lastDungeonPosition.spot + direction; i++)
            {
                nextLayer.Add(null);
            }

            var d = new SpaceDungeon();

            nextLayer.Add(d);
            dungeons.Add(nextLayer);

            var c = d + dungeons[lastDungeonPosition.layer][lastDungeonPosition.spot];
            connections.Add(c);

            lastDungeonPosition = new Position(dungeons, nextLayer, d);

            spawnedDungeonCount++;
        }

        for (int x = 0; x < dungeons.Count; x++)
        {
            for (int y = 0; y < dungeons[x].Count; y++)
            {
                if (dungeons[x][y] != null)
                {
                    mainPath.Add(new Position(x, y));
                }
            }
        }


    }

    public List<Position> PossibleBranchSpawnPoints()
    {
        List<Position> possible = new List<Position>();
        foreach (var p in mainPath)
        {
            Debug.Log(p.layer + " " + p.spot);
            if(p.layer == 0 || p.layer == dungeons.Count - 1)
            {
                continue;
            }
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (j == 0 && i == 0)
                    {
                        continue;
                    }
                    if (!possible.Exists(item => item.layer == p.layer + i && item.spot == p.spot + j) && !mainPath.Exists(item => item.layer == p.layer + i && item.spot == p.spot + j))
                    {
                        possible.Add(new Position(p.layer + i, p.spot + j));
                    }
                }
            }

        }

        return possible;
    }

    public void AddBranches()
    {
        List<Position> possibleDirections = PossibleBranchSpawnPoints();
        possibleDirections.ForEach(item => Debug.Log(item.layer + " " + item.spot));
    }



    //private List<SpaceDungeon> dungeons = new List<SpaceDungeon>();

    //public List<SpaceDungeon> Dungeons
    //{
    //    get
    //    {
    //        return dungeons;
    //    }
    //}


    //public LevelLayer(int maxNumberOfDungeons, int numberOfDungeons)
    //{
    //    for (int i = 0; i < maxNumberOfDungeons; i++)
    //    {
    //        dungeons.Add(null);
    //    }
    //    int addedDungeons = 0;
    //    while (addedDungeons < numberOfDungeons)
    //    {
    //        int posInLayer = Random.Range(0, maxNumberOfDungeons);
    //        if (dungeons[posInLayer] == null)
    //        {
    //            dungeons[posInLayer] = new SpaceDungeon();
    //            addedDungeons++;
    //        }
    //    }

    //}


    //public static List<SpaceDungeonConnection> operator +(LevelLayer l1, LevelLayer l2)
    //{
    //    List<SpaceDungeonConnection> connections = new List<SpaceDungeonConnection>();

    //    foreach (var d in l1.dungeons)
    //    {
    //        if (d != null && !d.HasConnection(connections))
    //        {
    //            List<SpaceDungeon> possibleConnectionPartners = new List<SpaceDungeon>();

    //            foreach(var cP in l2.dungeons)
    //            {
    //                if (cP != null)
    //                    possibleConnectionPartners.Add(cP);
    //            }
    //            Debug.Log(Random.seed);
    //            int howManyConnections = Random.Range(1, 3);
    //            int connectionsCreated = 0;
    //            while (connectionsCreated < howManyConnections)
    //            {
    //                int randomCPartner = Random.Range(0, possibleConnectionPartners.Count);
    //                var c = d + possibleConnectionPartners[randomCPartner];
    //                if (!c.DoesAlreadyExist(connections))
    //                {
    //                    connections.Add(c);
    //                    connectionsCreated++;
    //                    possibleConnectionPartners.Remove(possibleConnectionPartners[randomCPartner]);
    //                }
    //            }

    //        }
    //    }

    //    return connections;
    //}

}
