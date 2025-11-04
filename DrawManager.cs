namespace FinalAssignment;

public interface IDrawManager {

    /// <summary>
    /// 描画状態の更新を行う
    /// </summary>
    void UpdateDraw();
    
}

public sealed class DrawManager {
    
    private AppData m_appData = AppData.GetInstance();

    private IUnitManager m_units;
    
    private readonly char emptySymbol = '・';
    
    public DrawManager(IUnitManager unitManager) {
        m_units = unitManager;
    }

    public void UpdateDraw() {
        
        Console.Clear();
        
        Console.SetCursorPosition(0, m_appData.DrawTop);
        
        for (int y = 0; y < m_appData.MapHeight; y++) {
            for (int x = 0; x < m_appData.MapWidth; x++) {
                var pos = new Position(x, y);
                var unit = m_units.GetUnitAtPosition(pos);
                if (unit != null) {
                    Console.Write(unit.Symbol);
                } else {
                    Console.Write(emptySymbol);
                }
            }
            Console.WriteLine();
        }
    }
}