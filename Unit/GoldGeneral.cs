using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class GoldGeneral : APiece{
    
    public GoldGeneral (Position pos, Group group) : base('金', pos, group, new IMoveRule[] {
        new SlideMove(MoveDirection.Front),
        new SlideMove(MoveDirection.FrontRight),
        new SlideMove(MoveDirection.FrontLeft),
        new SlideMove(MoveDirection.Right),
        new SlideMove(MoveDirection.Left),
        new SlideMove(MoveDirection.Back)
    }) {
        
    }
}