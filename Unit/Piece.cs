namespace FinalAssignment;

public interface IPiece : IUnit {
    
    Group Group { get; }
    
}

public abstract class APiece : AUnit , IPiece{
    
    private Group m_group;
    
    public Group Group => m_group;
    
    protected APiece(char symbol, IPosition pos, Group group) : base(symbol, pos) {
        m_group = group;
    }
    
}