namespace FinalAssignment;

public interface IUnitManager<T> where T : IUnit {
    
    IReadOnlyList<T> Units { get; }
    
    void AddUnit(T unit);
    
    void RemoveUnit(T unit);
    
    T? GetUnitAtPosition(IPosition pos);
    
    void ClearUnits();
    
}

public class UnitManager<T> : IUnitManager<T> where T : IUnit {
    
    private List<T> m_units = new List<T>();
    
    public IReadOnlyList<T> Units => m_units;
    
    public void AddUnit(T unit) {
        m_units.Add(unit);
    }
    
    public void RemoveUnit(T unit) {
        m_units.Remove(unit);
    }
    
    public T? GetUnitAtPosition(IPosition pos) {
        foreach (var unit in m_units) {
            if (unit.Pos.X == pos.X && unit.Pos.Y == pos.Y) {
                return unit;
            }
        }
        return default;
    }
    
    public void ClearUnits() {
        m_units.Clear();
    }
}