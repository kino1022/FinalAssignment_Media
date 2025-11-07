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
    
    public static bool operator ==(Position a, Position b) => a.m_x == b.m_x && a.m_y == b.m_y;
    
    public static bool operator !=(Position a, Position b) => !(a == b);
    
    public static Position operator + (Position a, Position b) { 
        var x = a.X + b.X;
        var y = a.Y + b.Y;
        
        var next = new Position(x, y);
        if (next.IsInside()) {
            return next;
        }
        
        
        if (next.X < 0) x  = 0;
        if (next.X >= AppData.GetInstance().MapWidth) x= AppData.GetInstance().MapWidth - 1;
        if (next.Y < 0) y = 0;
        if (next.Y >= AppData.GetInstance().MapHeight) y = AppData.GetInstance().MapHeight - 1;
        
        return new Position(x, y);
    }

    public void SetPos(int x, int y) {
        
        if (CheckIntegrate(x, y) is false) throw new ArgumentOutOfRangeException();
        
        m_x = x;
        
        m_y = y;
        
    }
    
    public void SetPos(Position pos) {
        
        m_x = pos.X;
        
        m_y = pos.Y;
        
    }

    private bool CheckIntegrate(int x, int y) {
        
        if (x < 0 || x > AppData.GetInstance().MapWidth) return false;
        
        if (y < 0 || y > AppData.GetInstance().MapHeight) return false;
        
        return true;
    }
}

public static class PositionExtensions
{
    public static bool IsInside(this Position pos)
    {
        var app = AppData.GetInstance();
        
        return pos.X >= 0 && pos.X < app.MapWidth && pos.Y >= 0 && pos.Y < app.MapHeight;
    }
}