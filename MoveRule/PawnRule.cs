namespace FinalAssignment.MoveRule;

public class PawnRule : IMoveRule {
    public IEnumerable<Position> GetMoves(IPiece piece, IUnitManager<IPiece> pieces) {

        var app = AppData.GetInstance();

        var dir = piece.Group == Group.Red ? 1 : -1;

        int tx = piece.Pos.X;
        
        int ty = piece.Pos.Y + dir;
        
        if (IsInside(tx, ty, app) is false) yield break;
        
        var target = new Position(tx, ty);
        
        var occunpant = pieces.GetUnitAtPosition(target);

        if (occunpant is null) {
            yield return target;
        }
        else if (occunpant is IPiece p && occunpant.Group != piece.Group) {
            yield return target;
        }
        
    }
    
    private bool IsInside (int x, int y, AppData app) {
        return x >= 0 && x < app.MapWidth && y >= 0 && y < app.MapHeight;
    }
}