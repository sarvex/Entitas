public static class GameComponentsLookup {

    public const int Animating = 0;
    public const int Asset = 1;
    public const int GameBoardElement = 2;
    public const int GameOver = 3;
    public const int Health = 4;
    public const int Highscore = 5;
    public const int Interactive = 6;
    public const int Movable = 7;
    public const int Player = 8;
    public const int Position = 9;
    public const int User = 10;
    public const int Velocity = 11;
    public const int View = 12;

    public const int TotalComponents = 13;

    public static readonly string[] componentNames = {
        "Animating",
        "Asset",
        "GameBoardElement",
        "GameOver",
        "Health",
        "Highscore",
        "Interactive",
        "Movable",
        "Player",
        "Position",
        "User",
        "Velocity",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(AnimatingComponent),
        typeof(AssetComponent),
        typeof(GameBoardElementComponent),
        typeof(GameOverComponent),
        typeof(HealthComponent),
        typeof(HighscoreComponent),
        typeof(InteractiveComponent),
        typeof(MovableComponent),
        typeof(PlayerComponent),
        typeof(PositionComponent),
        typeof(UserComponent),
        typeof(VelocityComponent),
        typeof(ViewComponent)
    };
}
