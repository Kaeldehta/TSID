using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField]
    private int minMainPathLength = 5;
    [SerializeField]
    private int maxMainPathLength = 10;

    [SerializeField]
    private GameObject dungeonIcon;
    [SerializeField]
    private GameObject possibleIcon;

    public static LevelMap Level;

    private void Start()
    {
        int mainPathLength = Random.Range(minMainPathLength, maxMainPathLength + 1);
        Debug.Log("Spawning " + mainPathLength + " Dungeons.");

        Level = new LevelMap(7);

        Level.AddBranches(5);

        Level.DrawConnections();
    }

}

