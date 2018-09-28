using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceDungeon
{
    private Scene dungeonScene;
    private int id;
    private Vector2Int mapPosition;
    private bool isOnMainPath;
    private bool canBranch;

    private static int nextId = 0;

    public SpaceDungeon(int x, int y, bool _isOnMainPath, bool _canBranch)
    {
        isOnMainPath = _isOnMainPath;
        canBranch = _canBranch;
        mapPosition = new Vector2Int(x, y);
        dungeonScene = SceneManager.CreateScene("dungeon" + nextId);
        id = nextId;
        nextId++;
    }

    public Vector2Int MapPosition
    {
        get => mapPosition;
    }
    public bool IsOnMainPath
    {
        get => isOnMainPath;
    }
    public bool CanBranch
    {
        get => canBranch;
    }

    public override string ToString()
    {
        return id.ToString();
    }

    public static SpaceDungeonConnection operator +(SpaceDungeon d1, SpaceDungeon d2)
    {
        return new SpaceDungeonConnection(d1, d2);

    }
    
}
