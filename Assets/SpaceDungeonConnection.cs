public class SpaceDungeonConnection
{
    private SpaceDungeon dungeon1;
    private SpaceDungeon dungeon2;

    public SpaceDungeon FirstDungeon { get => dungeon1; }
    public SpaceDungeon SecondDungeon { get => dungeon2; }

    public SpaceDungeonConnection(SpaceDungeon _dungeon1, SpaceDungeon _dungeon2)
    {
        dungeon1 = _dungeon1;
        dungeon2 = _dungeon2;
    }
    
}
