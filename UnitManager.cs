namespace FinalAssignment;

public interface IUnitManager {
    
    IReadOnlyList<IUnit> Units { get; }
    
    void AddUnit(IUnit unit);
    
    void RemoveUnit(IUnit unit);
    
    IUnit? GetUnitAtPosition(IPosition pos);
    
    void ClearUnits();
    
}

public class UnitManager : IUnitManager {
    
    private List<IUnit> m_units = new List<IUnit>();
    
    public IReadOnlyList<IUnit> Units => m_units;
    
    public void AddUnit(IUnit unit) {
        m_units.Add(unit);
    }
    
    public void RemoveUnit(IUnit unit) {
        m_units.Remove(unit);
    }
    
    public IUnit? GetUnitAtPosition(IPosition pos) {
        foreach (var unit in m_units) {
            if (unit.Pos.X == pos.X && unit.Pos.Y == pos.Y) {
                return unit;
            }
        }
        return null;
    }
    
    public void ClearUnits() {
        m_units.Clear();
    }
}