using FinalAssignment.MoveRule;

namespace FinalAssignment;

public interface IPiece : IUnit {
    
    Group Group { get; }
    
    IEnumerable<IPosition> Positions { get; }
    
}

public abstract class APiece : AUnit , IPiece{
    
    private Group m_group;
    
    private IMoveRule m_moveRule;
    
    public Group Group => m_group;

    public IEnumerable<IPosition> Positions => m_moveRule.GetMoves(this);
    
    protected APiece(char symbol, IPosition pos, Group group, IMoveRule rule) : base(symbol, pos) {
        
        m_group = group;
        
        m_moveRule = rule;
        
    }
    
}