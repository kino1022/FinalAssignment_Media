using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Pawn : APiece{
    
    public Pawn (IPosition pos, Group group) : base('歩', pos, group, new PawnRule()) {
        
    }
}