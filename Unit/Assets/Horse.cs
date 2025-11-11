using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Horse : APiece {
    
    public Horse(Position pos, Group group) : base('馬', pos, group, new IMoveRule[] {
        new SlideMove(MoveDirection.FrontRight, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.BackRight, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.BackLeft, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.FrontLeft, AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.Front),
        new SlideMove(MoveDirection.Right),
        new SlideMove(MoveDirection.Left),
        new SlideMove(MoveDirection.Back)
    }) {

    }
}