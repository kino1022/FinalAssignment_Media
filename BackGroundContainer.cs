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
    
    private Dictionary<Position, ConsoleColor> _colors = new();
    
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
       var exist = _colors.Keys
           .ToList()
           .Exists(x => x.X == pos.X && x.Y == pos.Y);
       
       if (exist is false) {
           return;
       }
       
       _colors.Remove(pos);
    }

    public void Clear()
    {
        _colors.Clear();
    }
}