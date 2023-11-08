public enum GameMode
{
    Menu,
    InGame
}

public class GameManager : UnitySingleton<GameManager>
{
    private GameMode _currentGameMode = GameMode.Menu;

    public void SwitchGameMode(GameMode newGameMode)
    {
        _currentGameMode = newGameMode;
    }
}