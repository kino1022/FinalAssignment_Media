namespace FinalAssignment;

public static class PieceExtension {
    
    public static void JobChange(this APiece piece, APiece next) {
        var units = UnitManager.GetInstance();
        
        if (units.Units.Contains(piece) == false) {
            throw new InvalidOperationException("The piece to be changed is not managed by UnitManager.");
        }
        
        var pos = piece.Pos;
        
        units.RemoveUnit(piece);
        
        next.SetPos(pos.X, pos.Y);
        
        units.AddUnit(next);
    }
    
}