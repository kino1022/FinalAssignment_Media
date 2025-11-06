using System.Diagnostics;
using FinalAssignment.Input;

namespace FinalAssignment.State;

/// <summary>
/// プログラム開始時にEnterキーを押下するまで待機する状態
/// </summary>
public class GameStartState : IGameState {

    private readonly IGameStateManager _stateManager = GameStateManager.GetInstance();

    private readonly IDrawManager _draw = DrawManager.GetInstance();
    
    private readonly IInputManager _input = InputManager.GetInstance();
    
    private bool _loopFlag = true;
    
    public void Enter() {
        
        _draw.InfoMessage = "Enterを押下して開始";
        _draw.DebugMessage = "CurrentState: GameStartState";
        
    }

    public void Update() {
        // InputManager のキューから Enter を取り出して遷移させる
        if (_input.Queue.TryPeek(out var raw)) {
            if (raw.Key == ConsoleKey.Enter)
            {
                _input.Queue.TryDequeue(out _);
                _draw.DebugMessage = "Enter was pressed.";
                var next = new SelectPiecePhase(group: Group.Red);
                _stateManager.ChangeState(next);
            }
            // Enter 以外は他のコンポーネントで処理するため破棄
        }
    }
    
    public void Exit() {

        _draw.InfoMessage = string.Empty;
        _draw.DebugMessage = "StartState was exited.";
        
    }
    
    
}