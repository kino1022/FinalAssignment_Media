using System.Diagnostics;
using FinalAssignment.Cursor;
using FinalAssignment.Input;

namespace FinalAssignment.State;

public class SelectPiecePhase : IGameState
{
    private readonly Group _group;

    private readonly IPlayerCursor _cursor = PlayerCursor.GetInstance();
    
    private readonly IDrawManager _draw = DrawManager.GetInstance();
    
    private readonly IInputManager _input = InputManager.GetInstance();
    
    private readonly IUnitManager<APiece> _unit = UnitManager.GetInstance();
    
    public SelectPiecePhase(Group group)
    {
        _group = group;
    }

    public void Enter() {
        _draw.InfoMessage = "動かす駒を選択してください";
        _draw.DebugMessage = "SelectPiecePhase.Enter called";
    }

    public void Update() {
        if (_input.Queue.TryDequeue(out var raw)) {
            _draw.DebugMessage = $"SelectPiecePhase: dequeued {raw.Key}";
            if (raw.Key == ConsoleKey.Enter) {
                
                var unit = _unit.GetUnitAtPosition(_cursor.Position);
                
                if (unit is not null && unit.Group == _group) {
                    _draw.DebugMessage = $"{_group}の{unit.GetType().Name}が選択されました。";
                    // 選択された駒を引数に次の状態へ遷移
                    GameStateManager.GetInstance().ChangeState(new SelectDestinationPhase(unit));
                }
                else {
                    _draw.DebugMessage = "選択できない駒が選択されました。";
                    GameStateManager.GetInstance().ChangeState(new SelectPiecePhase(_group));
                }
                
            }
        }
    }

    public void Exit()
    {
        _draw.InfoMessage = "";
        
        _draw.DebugMessage = "SelectPiecePhase was exited.";
    }
}