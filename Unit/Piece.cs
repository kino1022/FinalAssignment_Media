using FinalAssignment.MoveRule;

namespace FinalAssignment;

public interface IPiece : IUnit {
    
    Group Group { get; }
    
    IEnumerable<Position> Positions { get; }
    
}

public abstract class APiece : AUnit , IPiece{
    
    private Group m_group;
    
    private IMoveRule[] m_moveRules;
    
    public Group Group => m_group;

    public IEnumerable<Position> Positions => GetPositions();
    
    protected APiece(char symbol, Position pos, Group group, IMoveRule[] rule) : base(symbol, pos) {
        
        if (rule == null || rule.Length == 0) {
            throw new ArgumentException("MoveRule is null or empty");
        }
        
        m_group = group;
        
        m_moveRules = rule;

    }
    
    public IEnumerable<Position> GetPositions () {
        
        if (m_moveRules.Length == 1) {
            return m_moveRules[0].GetMoves(this);
        }

        var rule = m_moveRules[0].GetMoves(this);
        
        for (int i = 1; i < m_moveRules.Length; i++) {
            rule = rule.Concat(m_moveRules[i].GetMoves(this));
        }

        return rule;
        
    }
}