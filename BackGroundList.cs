namespace FinalAssignment;

/// <summary>
/// 背景描画をする際の座標と色を管理するクラス
/// </summary>
public interface IBackGroundContainer
{
    IReadOnlyDictionary<IPosition, ConsoleColor> Colors { get; }
    
    void AddDraw(IPosition position, ConsoleColor color);
    
    void RemoveDraw(IPosition position);

    void Clear();
}

public class BackGroundContainer : IBackGroundContainer
{
    private static readonly IBackGroundContainer _instance = new BackGroundContainer();
    
    private Dictionary<IPosition, ConsoleColor> _colors = new();
    
    public IReadOnlyDictionary<IPosition, ConsoleColor> Colors => _colors;
    
    public static IBackGroundContainer GetInstance() => _instance;

    public void AddDraw(IPosition pos, ConsoleColor color)
    {
        // 既に存在する場合は上書き、存在しない場合は追加
        _colors[pos] = color;
    }

    public void RemoveDraw(IPosition pos)
    {
        _colors.Remove(pos);
    }

    public void Clear()
    {
        _colors.Clear();
    }
}