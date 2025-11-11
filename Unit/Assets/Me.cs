using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Me : APiece {
    
    public Me(Position pos, Group group) : base('俺', pos, group, new[] {
        new SlideMove(MoveDirection.Back)
    }) {
        
    }
    
}