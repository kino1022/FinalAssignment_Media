namespace FinalAssignment.State;

public interface IGameStateManager {
    
    /// <summary>
    /// 現在のステート
    /// </summary>
    IGameState CurrentState { get; }
    
    /// <summary>
    /// ステートの変更を行う
    /// </summary>
    /// <param name="newState"></param>
    void ChangeState(IGameState newState);
    
}

public sealed class GameStateManager  : IGameStateManager {
    
    private static GameStateManager _instance = new GameStateManager();

    private IGameState _currentState = new GameStartState();
    
    public static GameStateManager GetInstance() => _instance;
    
    public IGameState CurrentState => _currentState;

    public void ChangeState(IGameState newState) {
        
        _currentState?.Exit();

        _currentState = newState;
        
        _currentState?.Enter();
        
        _currentState?.Start();

    }
}