namespace FinalAssignment.State;

/// <summary>
/// プログラム開始時にEnterキーを押下するまで待機する状態
/// </summary>
public class GameStartState : IGameState {

    private IGameStateManager _stateManager = GameStateManager.GetInstance();

    private IDrawManager _draw;
    
    private bool _loopflag = true;

    public GameStartState(IDrawManager drawManager) {
        _draw = drawManager;
    }
    
    public void Enter() {
        
        _draw.InfoMessage = "Enterを押下して開始";
        
    }

    public void Start() {
        
        while (_loopflag) {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) {
                _loopflag = false;
            }
        }
        
        _stateManager.ChangeState();
    }
    
    public void Exit() {
        
        _draw.InfoMessage = string.Empty;
        
    }
    
    
}