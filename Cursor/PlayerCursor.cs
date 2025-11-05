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

public sealed class PlayerCursor : IPlayerCursor
{
    
    private IPlayerCursor _instance = new  PlayerCursor();
    
    private IPosition _pos = new Position(0,0);
    
    public IPosition Position => _pos;
    
    private Action<Position> _onEnter;

    public IPlayerCursor GetInstance() => _instance;

    public Action<Position> OnEnter => _onEnter;
    
    //シングルトンクラスのコンストラクタ内で非同期の入力検知とイベント発火を行う方法を考える。
    //もしだめならIGameState側で入力検知を行うことになる。
}