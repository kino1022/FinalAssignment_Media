using System.Diagnostics;
using FinalAssignment.Input;

namespace FinalAssignment.State;

/// <summary>
/// プログラム開始時にEnterキーを押下するまで待機する状態
/// </summary>
public class GameStartState : IGameState {
    
    
    private readonly IInputManager _input = InputManager.GetInstance();
    
    private bool _loopFlag = true;
    
    public void Enter() {
        
        var draw = DrawManager.GetInstance();
        
        draw.InfoMessage = "Enterを押下して開始";
        draw.DebugMessage = "CurrentState: GameStartState";
        
    }

    public void Update() {
        // InputManager のキューから Enter を取り出して遷移させる
        if (_input.Queue.TryPeek(out var raw)) {
            if (raw.Key == ConsoleKey.Enter)
            {
                _input.Queue.TryDequeue(out _);
                var draw = DrawManager.GetInstance();
                draw.DebugMessage = "Enter was pressed.";
                var next = new SelectPiecePhase(group: Group.Red);

                var stateManager = GameStateManager.GetInstance();
                stateManager.ChangeState(next);
            }
            // Enter 以外は他のコンポーネントで処理するため破棄
        }
    }
    
    public void Exit() {
        
        var draw = DrawManager.GetInstance();

        draw.InfoMessage = string.Empty;
        draw.DebugMessage = "StartState was exited.";
        
    }
    
    
}