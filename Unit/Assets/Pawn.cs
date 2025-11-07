using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Pawn : APiece{
    
    public Pawn (Position pos, Group group) : base('歩', pos, group, new IMoveRule[] {
        new SlideMove(MoveDirection.Front)
    }) {
        
    }
}