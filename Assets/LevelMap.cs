using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap
{
    private List<SpaceDungeon> dungeons = new List<SpaceDungeon>();
    private List<SpaceDungeonConnection> connections = new List<SpaceDungeonConnection>();

    public List<SpaceDungeon> Dungeons { get => dungeons; }
    public List<SpaceDungeonConnection> Connections { get => connections; }

    public LevelMap(int mainPathLength)
    {
        SpaceDungeon firstDungeon = new SpaceDungeon(0, 0, true, false);
        dungeons.Add(firstDungeon);

        for (int i = 0; i < mainPathLength; i++)
        {
            int direction = Random.Range(-1, 2);

            bool canBranch = i != (mainPathLength - 1);

            SpaceDungeon dungeon = new SpaceDungeon(i + 1, dungeons[i].MapPosition.y + direction, true, canBranch);
            dungeons.Add(dungeon);
            connections.Add(dungeons[i] + dungeon);
        }

    }

    public Dictionary<SpaceDungeon, List<Vector2Int>> PossibleBranchSpawnPoints()
    {
        Dictionary<SpaceDungeon, List<Vector2Int>> possible = new Dictionary<SpaceDungeon, List<Vector2Int>>();
        foreach (var dungeon in dungeons)
        {
            List<Vector2Int> possibleForThisPath = new List<Vector2Int>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Vector2Int newPos = new Vector2Int(dungeon.MapPosition.x + i, dungeon.MapPosition.y + j);
                    if (!dungeons.Exists(item => item.MapPosition == newPos))
                    {
                        possibleForThisPath.Add(newPos);
                    }
                    else
                    {
                        Debug.Log("Already in dungeons.");
                    }
                }
            }

            possible.Add(dungeon, possibleForThisPath);

        }

        return possible;
    }

    public void DrawConnections()
    {
        Debug.Log(connections.Count);
        foreach (var c in connections)
        {
            Vector2Int d1 = c.FirstDungeon.MapPosition;
            Vector2Int d2 = c.SecondDungeon.MapPosition;

            Vector3 realPosD1 = new Vector3(d1.x * 5, d1.y * 5, 0);
            Vector3 realPosD2 = new Vector3(d2.x * 5, d2.y * 5, 0);

            Debug.DrawRay(realPosD1, realPosD2 - realPosD1, Color.red, 20);
        }
    }

    public void AddBranches(int branchCount)
    {
        List<SpaceDungeon> hasBranch = new List<SpaceDungeon>();
        for (int i = 0; i < branchCount; i++)
        {
            Dictionary<SpaceDungeon, List<Vector2Int>> possibleRootsOrig = PossibleBranchSpawnPoints();
            Dictionary<SpaceDungeon, List<Vector2Int>> possibleRoots = PossibleBranchSpawnPoints();
            foreach (var key in possibleRootsOrig.Keys)
            {
                if (!key.IsOnMainPath || !key.CanBranch)
                {
                    possibleRoots.Remove(key);
                }

            }

            foreach (var b in hasBranch)
            {
                if (possibleRoots.ContainsKey(b))
                    possibleRoots.Remove(b);
            }

            int randomRootIndex = Random.Range(0, possibleRoots.Keys.Count);

            SpaceDungeon[] keyArray = new SpaceDungeon[possibleRoots.Keys.Count];

            possibleRoots.Keys.CopyTo(keyArray, 0);

            SpaceDungeon root = keyArray[randomRootIndex];
            hasBranch.Add(root);

            List<Vector2Int> possibleBranches = possibleRoots[root];

            int randomBranchIndex = Random.Range(0, possibleBranches.Count);

            Vector2Int branch = possibleBranches[randomBranchIndex];

            SpaceDungeon branchDungeon = new SpaceDungeon(branch.x, branch.y, false, true);
            dungeons.Add(branchDungeon);

            connections.Add(root + branchDungeon);

        }

    }

    
}

