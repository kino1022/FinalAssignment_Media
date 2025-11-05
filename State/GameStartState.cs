namespace FinalAssignment.State;

/// <summary>
/// プログラム開始時にEnterキーを押下するまで待機する状態
/// </summary>
public class GameStartState : IGameState {

    private readonly IGameStateManager _stateManager = GameStateManager.GetInstance();

    private readonly IDrawManager _draw = DrawManager.GetInstance();
    
    private bool _loopFlag = true;
    
    public void Enter() {
        
        _draw.InfoMessage = "Enterを押下して開始";
        
    }

    public void Start() {
        
        while (_loopFlag) {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) {
                _loopFlag = false;
            }
        }
        
        _stateManager.ChangeState(new SelectPiecePhase(Group.Red));
    }
    
    public void Exit() {
        
        _draw.InfoMessage = string.Empty;
        
    }
    
    
}