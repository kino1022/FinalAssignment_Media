namespace FinalAssignment.MoveRule;

public class SlideMove : IMoveRule {
    
    private readonly MoveDirection _direction;

    private readonly int _length;

    public SlideMove(MoveDirection direction, int length = 1) {
        
        _direction = direction;
        
        _length = length;
        
    }

    public IEnumerable<Position> GetMoves(APiece piece) {
        var units = UnitManager.GetInstance();
        
        var pos = piece.Pos;

        var normalize = (int)piece.Group;

        var vec = _direction.ToVector();
        vec.x *= normalize;
        vec.y *= normalize;
        
        for(int step = 1; step <=_length; step++) {
            // 移動先の絶対座標を先に計算する
            int targetX = pos.X + vec.x * step;
            int targetY = pos.Y + vec.y * step;

            var app = AppData.GetInstance();
            // 盤外ならそこで打ち切る
            if (targetX < 0 || targetX >= app.MapWidth || targetY < 0 || targetY >= app.MapHeight) break;

            var next = new Position(targetX, targetY);

            var previous = units.GetUnitAtPosition(next);

            if (previous is null) {
                yield return next;
                continue;
            }
            
            if ( previous.Group != piece.Group) {
                yield return next;
            }
            
            break;
        }
    }
}