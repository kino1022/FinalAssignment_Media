namespace FinalAssignment;

public interface IDrawManager {
    
    string InfoMessage { get; set; }

    /// <summary>
    /// 描画状態の更新を行う
    /// </summary>
    void UpdateDraw();
    
}

public sealed class DrawManager : IDrawManager {
    
    private AppData m_appData = AppData.GetInstance();

    private IUnitManager<IPiece> m_units;
    
    private readonly char emptySymbol = '・';

    public string InfoMessage { get; set; }

    public DrawManager(IUnitManager<IPiece> unitManager) {
        m_units = unitManager;
    }

    public void UpdateDraw() {
        
        Console.Clear();
        
        Console.SetCursorPosition(0, m_appData.DrawTop);
        
        Console.WriteLine(InfoMessage);
        
        for (int y = 0; y < m_appData.MapHeight; y++) {
            for (int x = 0; x < m_appData.MapWidth; x++) {
                var pos = new Position(x, y);
                var unit = m_units.GetUnitAtPosition(pos);
                
                if (unit != null) {
                    Console.ForegroundColor = unit.Group.ToColor();
                    Console.Write(unit.Symbol);
                    Console.ResetColor();
                } else {
                    Console.Write(emptySymbol);
                }
            }
            Console.WriteLine();
        }
    }
}