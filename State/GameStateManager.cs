namespace FinalAssignment.State;

public interface IGameStateManager {
    
    IGameState CurrentState { get; }
    
    void ChangeState(IGameState newState);
    
}

public sealed class GameStateManager  : IGameStateManager {
    
    private static GameStateManager _instance = new GameStateManager();
    
    private IGameState _currentState = null;
    
    public static GameStateManager GetInstance() => _instance;
    
    public IGameState CurrentState => _currentState;

    public void ChangeState(IGameState newState) {
        
        _currentState?.Exit();

        _currentState = newState;
        
        _currentState?.Enter();
        
    }
}