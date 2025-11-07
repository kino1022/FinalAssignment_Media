using FinalAssignment.MoveRule;

namespace FinalAssignment;

public class Knight : APiece {
    
    public Knight(Position pos, Group group) : base('桂', pos, group, new MoveRule.IMoveRule[] {
        new KnightMoveRule()
    }) {

    }
}