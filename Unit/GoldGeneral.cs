using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class GoldGeneral : APiece{
    
    public GoldGeneral (Position pos, Group group) : base('金', pos, group, new IMoveRule[] {
        new SlideMove(SlideDirection.LeftFront, 1),
        new SlideMove(SlideDirection.LeftBack, 1),
    }) {
        
    }
}