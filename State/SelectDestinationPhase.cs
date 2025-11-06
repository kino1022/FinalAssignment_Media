using FinalAssignment.Cursor;
using FinalAssignment.Input;

namespace FinalAssignment.State;

public class SelectDestinationPhase : IGameState {
    
    private readonly APiece _unit;
    
    private readonly IDrawManager _draw = DrawManager.GetInstance();
    
    private readonly IBackGroundContainer _container = BackGroundContainer.GetInstance();
    
    private readonly IInputManager _input = InputManager.GetInstance();
    
    private readonly IPlayerCursor _cursor = PlayerCursor.GetInstance();
    
    private readonly IGameStateManager _state = GameStateManager.GetInstance();
    
    private readonly IUnitManager<APiece> _units = UnitManager.GetInstance();
    
    private List<IPosition> _destinations;

    private ConsoleColor _color = ConsoleColor.Yellow;

    public SelectDestinationPhase(APiece unit) {
        _unit = unit;
    }
    
    public void Enter() {
        
        _draw.InfoMessage = "移動先を選択してください";

        _destinations = _unit.Positions.ToList();
        
        _destinations.ForEach(x =>
        {
            _container.AddDraw(x, _color);
        });
        
    }

    public void Update() {
        if (_input.Queue.TryPeek(out var raw))
        {
            if (raw.Key is ConsoleKey.Enter)
            {
                _input.Queue.TryDequeue(out _);
                //移動先の座標であるかを確認
                if (_destinations.Exists(x => x == _cursor.Position))
                {
                    //そうだった場合は移動処理を呼び出し
                    var succes = MoveUnit(_cursor.Position);
                    if (succes)
                    {
                        _state.ChangeState(new SelectPiecePhase(_unit.Group == Group.Red ? Group.Blue : Group.Red));
                    }
                    else
                    {
                        _state.ChangeState(new SelectDestinationPhase(_unit));
                    }
                }
                else
                {
                    //違った場合は同じステートで初期化
                    _state.ChangeState(new SelectDestinationPhase(_unit));
                }
            }

            //BackSpace入力でキャンセル入力
            if (raw.Key is ConsoleKey.Backspace)
            {
                _input.Queue.TryDequeue(out _);
                _state.ChangeState(new SelectPiecePhase(_unit.Group));
            }
        }
    }

    public void Exit() {
        _destinations.ForEach(x =>
        {
            _container.RemoveDraw(x);
        });
    }

    private bool MoveUnit(IPosition pos)
    {
        var previous = _units.GetUnitAtPosition(pos);

        //先客がいなければ単純に移動
        if (previous is null)
        {
            _unit.Pos.SetPos(pos.X, pos.Y);
            return true;
        }
        //先客がいてグループが違うなら取る
        else if (previous.Group != _unit.Group)
        {
            _units.RemoveUnit(previous);
            _unit.Pos.SetPos(pos.X, pos.Y);
            return true;
        }
        else
        {
            return false;
        }

        return false;
    }
}