using System.Threading.Tasks;

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
    
    private AppData _app = AppData.GetInstance();

    private IGameState _currentState = new GameStartState();
    
    public static GameStateManager GetInstance() => _instance;
    
    public IGameState CurrentState => _currentState;

    public GameStateManager() {
        DrawManager.GetInstance().DebugMessage = "GameStateManager initialized.";
        // GameCycle は非同期メソッドなので、Fire-and-forget で起動する
        // 明示的に Task.Run でバックグラウンド実行するように変更
        Task.Run(
            () => GameCycle()
        );
    }

    private async Task GameCycle() {
        while (_app.LoopFlag) {

            // 2) ステート更新
            if (_currentState is not null) {
                _currentState.Update();
            }
            
            // CPU 負荷を下げるために短い delay を入れる
            await Task.Delay(10);
        }
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