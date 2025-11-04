namespace FinalAssignment;

public interface IPosition {
    int X { get; }
    
    int Y { get; }
    
    void SetPos(int x, int y);
}

public struct Position : IPosition {

    private int m_x = 0;
    
    private int m_y = 0;
    
    public int X => m_x;
    
    public int Y => m_y;

    public Position(int x, int y) {

        if (CheckIntegrate(x, y) is false) throw new ArgumentOutOfRangeException();
        
        m_x = x;
        
        m_y = y;
    }

    public void SetPos(int x, int y) {
        
        if (CheckIntegrate(x, y) is false) throw new ArgumentOutOfRangeException();
        
        m_x = x;
        
        m_y = y;
        
    }

    private bool CheckIntegrate(int x, int y) {
        
        if (x < 0 || x > AppData.GetInstance().MapWidth) return false;
        
        if (y < 0 || y > AppData.GetInstance().MapHeight) return false;
        
        return true;
    }
}