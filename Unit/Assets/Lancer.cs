namespace FinalAssignment;

public class Lancer : APiece {
    
    public Lancer(Position position, Group group) : base('香', position, group, new MoveRule.IMoveRule[] {
        new MoveRule.SlideMove(MoveRule.MoveDirection.Front, AppData.GetInstance().MapHeight)
    }) {

    }
}