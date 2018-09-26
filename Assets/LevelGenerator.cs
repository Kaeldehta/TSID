using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    /*[SerializeField]
    private int numberOfLayers = 1;
    [SerializeField]
    private int maxNumberOfDungeonsPerLayer = 3;*/

    [SerializeField]
    private int minMainPathLength = 5;
    [SerializeField]
    private int maxMainPathLength = 10;

    [SerializeField]
    private GameObject dungeonIcon;
    [SerializeField]
    private GameObject possibleIcon;

    //private List<LevelLayer> layers = new List<LevelLayer>();

    private void Start()
    {
        int mainPathLength = Random.Range(minMainPathLength, maxMainPathLength + 1);
        Debug.Log("Spawning " + mainPathLength + " Dungeons.");

        LevelMap lm = new LevelMap(mainPathLength);

        var dungeonPos = lm.DungeonVectors;
        var bPos = lm.PossibleBranchSpawnPoints();

        foreach(var d in dungeonPos)
        {
            Debug.Log("Dungeon: " + d.x + " " + d.y);
            var newPos = new Vector2(d.x * 5, d.y * 5);
            Instantiate(dungeonIcon, newPos, Quaternion.identity, transform);
        }
        foreach(var p in bPos)
        {
            var newPos = new Vector2(p.layer * 5, p.spot * 5);
            Instantiate(possibleIcon, newPos, Quaternion.identity, transform);
        }
        /*
        LevelLayer first = new LevelLayer(maxNumberOfDungeonsPerLayer, 1);
        layers.Add(first);
        for (int i = 0; i < numberOfLayers; i++)
        {
            int numberOfDungeonsInThisLayer = UnityEngine.Random.Range(1, maxNumberOfDungeonsPerLayer + 1);
            LevelLayer l = new LevelLayer(maxNumberOfDungeonsPerLayer, numberOfDungeonsInThisLayer);
            layers.Add(l);
        }
        LevelLayer last = new LevelLayer(maxNumberOfDungeonsPerLayer, 1);
        layers.Add(last);

        try
        {
            for (int i = 0; i < layers.Count - 1; i++)
            {
                var cList = layers[i] + layers[i + 1];
                connections.AddRange(cList);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error");
        }

        */

        //DrawLevelMap();
    }
    /*
    void DrawLevelMap()
    {
        for (int x = 0; x < layers.Count; x++)
        {

            for (int y = 0; y < layers[x].Dungeons.Count; y++)
            {
                if (layers[x].Dungeons[y] != null)
                {
                    GameObject d = Instantiate(dungeonIcon, new Vector2(x * 5, y * 3), Quaternion.identity, transform);
                    d.GetComponentInChildren<Text>().text = layers[x].Dungeons[y].ToString();
                }
            }

        }

        foreach (var c in connections)
        {
            Debug.Log(c.Dungeon1 + "        " + c.Dungeon2);
            Vector2 d1 = new Vector2();
            Vector2 d2 = new Vector2();

            for (int x = 0; x < layers.Count; x++)
            {
                int y1 = layers[x].Dungeons.IndexOf(c.Dungeon1);
                if (y1 != -1)
                {
                    d1 = new Vector2(x * 5, y1 * 3);
                    break;
                }

            }

            for (int x = 0; x < layers.Count; x++)
            {
                int y2 = layers[x].Dungeons.IndexOf(c.Dungeon2);
                if (y2 != -1)
                {
                    d2 = new Vector2(x * 5, y2 * 3);
                    break;
                }

            }


            Debug.DrawRay(d1, d2 - d1, Color.red, 10);
        }
        */

}

