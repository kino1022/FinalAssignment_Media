using System;

namespace FinalAssignment;

[Serializable]
public class Position  {

    private int m_x = 0;
    
    private int m_y = 0;
    
    public int X => m_x;
    
    public int Y => m_y;

    public Position(int x, int y) {

        if (CheckIntegrate(x, y) is false) throw new ArgumentOutOfRangeException();
        
        m_x = x;
        
        m_y = y;
    }

    public static bool operator ==(Position a, Position b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
        return a.m_x == b.m_x && a.m_y == b.m_y;
    }

    public static bool operator !=(Position a, Position b) => !(a == b);
    
    public static Position operator +(Position a, Position b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));

        var app = AppData.GetInstance();

        int x = a.X + b.X;
        int y = a.Y + b.Y;

        // 範囲外は盤内に丸める（clamp）
        if (app.MapWidth <= 0 || app.MapHeight <= 0)
        {
            // 安全策: 不正な AppData の場合は例外
            throw new InvalidOperationException("AppData has invalid map dimensions.");
        }

        x = Math.Clamp(x, 0, app.MapWidth - 1);
        y = Math.Clamp(y, 0, app.MapHeight - 1);

        return new Position(x, y);
    }
    public void SetPos(int x, int y) {
        
        if (CheckIntegrate(x, y) is false) throw new ArgumentOutOfRangeException();
        
        m_x = x;
        
        m_y = y;
        
    }
    
    public void SetPos(Position pos) {
        if (pos is null) throw new ArgumentNullException(nameof(pos));
        if (CheckIntegrate(pos.X, pos.Y) is false) throw new ArgumentOutOfRangeException();
        m_x = pos.X;
        m_y = pos.Y;
    }

    private bool CheckIntegrate(int x, int y) {
        var app = AppData.GetInstance();
        if (app == null) return false;
        if (app.MapWidth <= 0 || app.MapHeight <= 0) return false;
        // 正しい境界判定: 0 <= x < MapWidth, 0 <= y < MapHeight
        if (x < 0 || x >= app.MapWidth) return false;
        if (y < 0 || y >= app.MapHeight) return false;
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Position other) return false;
        return this == other;
    }

    public override int GetHashCode() => HashCode.Combine(m_x, m_y);
}

public static class PositionExtensions
{
    public static bool IsInside(this Position pos)
    {
        if (pos is null) return false;
        var app = AppData.GetInstance();
        if (app == null) return false;
        return pos.X >= 0 && pos.X < app.MapWidth && pos.Y >= 0 && pos.Y < app.MapHeight;
    }
}