using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Rook : APiece {
    
    public Rook(Position pos, Group group) : base('飛', pos, group, new IMoveRule[] {
        new SlideMove(MoveDirection.Front,AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.Back,AppData.GetInstance().MapHeight),
        new SlideMove(MoveDirection.Left,AppData.GetInstance().MapWidth),
        new SlideMove(MoveDirection.Right,AppData.GetInstance().MapWidth)
    }) {
        
    }
}