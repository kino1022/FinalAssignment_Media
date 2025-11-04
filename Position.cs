namespace FinalAssignment;

public interface IPosition {
    int X { get; }
    
    int Y { get; }
}

public struct Position : IPosition {

    private int m_x = 0;
    
    private int m_y = 0;
    
    public int X => m_x;
    
    public int Y => m_y;

    public Position(int x, int y) {
        
        if (x < 0) throw new ArgumentOutOfRangeException();
        
        if (y < 0) throw new ArgumentOutOfRangeException();
        
        m_x = x;
        
        m_y = y;
    }
}