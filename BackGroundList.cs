namespace FinalAssignment;

/// <summary>
/// 背景描画をする際の座標と色を管理するクラス
/// </summary>
public interface IBackGroundContainer
{
    IReadOnlyDictionary<Position, ConsoleColor> Colors { get; }
    
    void AddDraw(Position position, ConsoleColor color);
    
    void RemoveDraw(Position position);
}

public class BackGroundContainer : IBackGroundContainer
{
    private static readonly IBackGroundContainer _instance = new BackGroundContainer();
    
    private Dictionary<Position, ConsoleColor> _colors = new Dictionary<Position, ConsoleColor>();
    
    public IReadOnlyDictionary<Position, ConsoleColor> Colors => _colors;
    
    public static IBackGroundContainer GetInstance() => _instance;

    public void AddDraw(Position pos, ConsoleColor color)
    {
        if (_colors.TryGetValue(pos, out ConsoleColor col))
        {
            col = color;
        }
        else 
        {
            _colors.Add(pos, color);
        }
    }

    public void RemoveDraw(Position pos)
    {
        _colors.Remove(pos);
    }
}