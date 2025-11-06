using FinalAssignment.Input;

namespace FinalAssignment.Cursor;

public interface IPlayerCursor
{
    
    /// <summary>
    /// カーソルの存在する座標
    /// </summary>
    IPosition Position { get; }
    
    /// <summary>
    /// 決定した座標を引数に発火される決定のコールバック
    /// </summary>
    Action<Position> OnEnter { get; }
}

[Serializable]
public sealed class PlayerCursor : IPlayerCursor
{
    
    private static readonly IPlayerCursor _instance = new  PlayerCursor();
    
    private static readonly AppData _app = AppData.GetInstance();
    
    private static readonly IInputManager _input = InputManager.GetInstance();
    
    private static IPosition _pos = new Position(0,0);
    
    public IPosition Position => _pos;
    
    private Action<Position> _onEnter;

    public static IPlayerCursor GetInstance() => _instance;

    public Action<Position> OnEnter => _onEnter;
    
    //シングルトンクラスのコンストラクタ内で非同期の入力検知とイベント発火を行う方法を考える。
    //もしだめならIGameState側で入力検知を行うことになる。

    public PlayerCursor() {
        var task = Task.Run(() => CursorMove());
    }
 
    private async Task CursorMove() {
        while (_app.LoopFlag) {
            // キューを破壊的に処理せず、先頭を覗いて方向キーのみ取り出す。
            if (_input.Queue.TryPeek(out var keyInfo)) {
                switch (keyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        // 実際の取り出しは TryDequeue で行う
                        _input.Queue.TryDequeue(out _);
                        _pos = CalculatePos(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        _input.Queue.TryDequeue(out _);
                        _pos = CalculatePos(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        _input.Queue.TryDequeue(out _);
                        _pos = CalculatePos(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        _input.Queue.TryDequeue(out _);
                        _pos = CalculatePos(1, 0);
                        break;
                    case ConsoleKey.Enter:
                        // Enter は State 側で処理させるためここでは dequeue しない
                        break;
                    default:
                        // 不要なキーは取り除く
                        _input.Queue.TryDequeue(out _);
                        break;
                }
            }
            await Task.Delay(1);
         }
     }
    
    private static IPosition CalculatePos (int deltaX, int deltaY) {
        var app = AppData.GetInstance();
        var newX = _instance.Position.X + deltaX;
        var newY = _instance.Position.Y + deltaY;

        // 範囲外の座標で Position を直接構築すると例外が発生するため
        // ここで事前にチェックして安全に処理する
        if (newX >= 0 && newX < app.MapWidth && newY >= 0 && newY < app.MapHeight) {
            return new Position(newX, newY);
        }

        return _pos;
    }
}