namespace FinalAssignment;

public interface IUnit {
    
    /// <summary>
    /// 描画する際のシンボル文字
    /// </summary>
    char Symbol { get; }
    
    /// <summary>
    /// 存在する座標
    /// </summary>
    IPosition Pos { get; }
    
    /// <summary>
    /// 座標を変更する
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    void SetPos (int x, int y);
    
}

public abstract class AUnit : IUnit {

    private char m_synbol;

    private IPosition m_pos;
    
    public IPosition Pos => m_pos;
    
    public char Symbol => m_synbol;
    
    protected AUnit(char symbol, IPosition pos) {
        m_synbol = symbol;

        m_pos = pos;
    }

    public void SetPos (int x, int y) => m_pos.SetPos(x, y);
    
}