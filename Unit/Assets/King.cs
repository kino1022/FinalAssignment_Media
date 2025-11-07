using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class King : APiece {
    
    public King(Position pos, Group group) : base('玉', pos, group, new IMoveRule[] {
        new SlideMove(MoveDirection.Front)
        , new SlideMove(MoveDirection.FrontRight)
        , new SlideMove(MoveDirection.Right)
        , new SlideMove(MoveDirection.BackRight)
        , new SlideMove(MoveDirection.Back)
        , new SlideMove(MoveDirection.BackLeft)
        , new SlideMove(MoveDirection.Left)
        , new SlideMove(MoveDirection.FrontLeft)
    }) {
        
    }
}