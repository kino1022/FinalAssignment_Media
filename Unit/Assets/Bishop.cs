using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Bishop : APiece{
    
    public Bishop (Position position, Group group) : base ('角',position, group, new MoveRule.IMoveRule[] {
        new SlideMove(MoveDirection.FrontRight, AppData.GetInstance().MapHeight),
        new  SlideMove(MoveDirection.BackRight, AppData.GetInstance().MapHeight),
        new  SlideMove(MoveDirection.FrontLeft, AppData.GetInstance().MapHeight),
        new  SlideMove(MoveDirection.BackLeft, AppData.GetInstance().MapHeight)
    }){

    }
}