public partial class GameContext {

    public GameEntity highscoreEntity { get { return GetGroup(GameMatcher.Highscore).GetSingleEntity(); } }
    public HighscoreComponent highscore { get { return highscoreEntity.highscore; } }
    public bool hasHighscore { get { return highscoreEntity != null; } }

    public GameEntity SetHighscore(int newValue) {
        if (hasHighscore) {
            throw new Entitas.EntitasException("Could not set Highscore!\n" + this + " already has an entity with HighscoreComponent!",
                "You should check if the context already has a highscoreEntity before setting it or use context.ReplaceHighscore().");
        }
        var entity = CreateEntity();
        entity.AddHighscore(newValue);
        return entity;
    }

    public void ReplaceHighscore(int newValue) {
        var entity = highscoreEntity;
        if (entity == null) {
            entity = SetHighscore(newValue);
        } else {
            entity.ReplaceHighscore(newValue);
        }
    }

    public void RemoveHighscore() {
        highscoreEntity.Destroy();
    }
}

public partial class GameEntity {

    public HighscoreComponent highscore { get { return (HighscoreComponent)GetComponent(GameComponentsLookup.Highscore); } }
    public bool hasHighscore { get { return HasComponent(GameComponentsLookup.Highscore); } }

    public void AddHighscore(int newValue) {
        var index = GameComponentsLookup.Highscore;
        var component = (HighscoreComponent)CreateComponent(index, typeof(HighscoreComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHighscore(int newValue) {
        var index = GameComponentsLookup.Highscore;
        var component = (HighscoreComponent)CreateComponent(index, typeof(HighscoreComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHighscore() {
        RemoveComponent(GameComponentsLookup.Highscore);
    }
}

public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHighscore;

    public static Entitas.IMatcher<GameEntity> Highscore {
        get {
            if (_matcherHighscore == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Highscore);
                matcher.ComponentNames = GameComponentsLookup.componentNames;
                _matcherHighscore = matcher;
            }

            return _matcherHighscore;
        }
    }
}
