namespace FinalAssignment;

/// <summary>
/// 背景描画をする際の座標と色を管理するクラス
/// </summary>
public interface IBackGroundContainer
{
    IReadOnlyDictionary<Position, ConsoleColor> Colors { get; }
    
    void AddDraw(Position position, ConsoleColor color);
    
    void RemoveDraw(Position position);

    void Clear();
}

public class BackGroundContainer : IBackGroundContainer
{
    private static readonly IBackGroundContainer _instance = new BackGroundContainer();
    
    private Dictionary<Position, ConsoleColor> _colors = new Dictionary<Position, ConsoleColor>();
    
    public IReadOnlyDictionary<Position, ConsoleColor> Colors => _colors;
    
    public static IBackGroundContainer GetInstance() => _instance;

    public void AddDraw(Position pos, ConsoleColor color)
    {
        // 既に存在する場合は上書き、存在しない場合は追加
        _colors[pos] = color;
    }

    public void RemoveDraw(Position pos)
    {
        _colors.Remove(pos);
    }

    public void Clear()
    {
        _colors.Clear();
    }
}