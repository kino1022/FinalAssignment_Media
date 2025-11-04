namespace FinalAssignment;

public interface IPiece : IUnit {
    
    Group Group { get; }
    
}

public class Piece : AUnit , IPiece{
    
    private Group m_group;
    
    public Group Group => m_group;
    
    public Piece(char symbol, IPosition pos, Group group) : base(symbol, pos) {
        m_group = group;
    }
    
}