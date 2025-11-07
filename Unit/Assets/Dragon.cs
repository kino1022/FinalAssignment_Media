using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Dragon : APiece {
    
    public Dragon(Position pos, Group group) : base('龍', pos, group, new MoveRule.IMoveRule[] {
        new SlideMove(MoveDirection.Front),
        new SlideMove(MoveDirection.Back),
        new SlideMove(MoveDirection.Left),
        new SlideMove(MoveDirection.Right),
        new SlideMove(MoveDirection.FrontRight, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.FrontLeft, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.BackRight, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.BackLeft, AppData.GetInstance().MapHeight)  
    }) {

    }
}