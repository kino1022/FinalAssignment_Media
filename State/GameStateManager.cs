using System.Threading.Tasks;

namespace FinalAssignment.State;

public interface IGameStateManager {
    
    /// <summary>
    /// 現在のステート
    /// </summary>
    IGameState CurrentState { get; }

    void Update();
    
    /// <summary>
    /// ステートの変更を行う
    /// </summary>
    /// <param name="newState"></param>
    void ChangeState(IGameState newState);
    
}

public sealed class GameStateManager  : IGameStateManager {
    
    private static readonly GameStateManager _instance = new GameStateManager();
    
    private AppData _app = AppData.GetInstance();

    private IGameState _currentState = new GameStartState();
    
    public static GameStateManager GetInstance() => _instance;
    
    public IGameState CurrentState => _currentState;

    public GameStateManager() { }

    public void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(IGameState newState)
    {

        var drawer = DrawManager.GetInstance();
        
        drawer.DebugMessage = "ChangeState was called.";
        
        var previousState = _currentState;
        
        _currentState = newState;
        
        previousState.Exit();
        
        _currentState.Enter();

    }
}