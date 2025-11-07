using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class SilverGeneral : APiece {
    
    public SilverGeneral(Position pos, Group group) : base('銀', pos, group, new IMoveRule[] {
        new SlideMove(MoveDirection.Front),
        new SlideMove(MoveDirection.FrontLeft),
        new SlideMove(MoveDirection.FrontRight),
        new SlideMove(MoveDirection.BackLeft),
        new SlideMove(MoveDirection.BackRight)
    }) {
        
    }
}