namespace FinalAssignment.MoveRule;

public abstract class AMoveRule : IMoveRule {

    private (int vertical, int horizontal)[] _destinations;
    
    protected AMoveRule((int vertical, int horizontal)[] destinations) {

        if (destinations.Length is 0) {
            throw new ArgumentOutOfRangeException(nameof(destinations));
        }
        
        _destinations = destinations;
    }
    
    public IEnumerable<IPosition> GetMoves (APiece piece) {
        
        var pos = piece.Pos;

        var destinations = _destinations;
        
        // グループに応じて移動方向を変える
        destinations.ToList().ForEach(x => {
            x.vertical *= (int)piece.Group;
            x.horizontal *= (int)piece.Group;
        });
        
        foreach (var destination in destinations) {
            
            var next = new Position(pos.X + destination.horizontal, pos.Y + destination.vertical);
            
            if (next.IsInside()) {
                yield return next;
            }
            else {
                yield break;
            }
            
        }
    }
    
    private bool IsInside (int x, int y, AppData app) {
        return x >= 0 && x < app.MapWidth && y >= 0 && y < app.MapHeight;
    }
}