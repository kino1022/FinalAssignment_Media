namespace FinalAssignment.MoveRule;

public class KnightMoveRule : IMoveRule {
    
    public IEnumerable<Position> GetMoves(APiece piece) {
        var directions = new (int x, int y)[] {
            (-1, 2),
            (1, 2)
        };

        foreach (var (dx, dy) in directions) {
            var normalize = (int)piece.Group;
            int targetX = piece.Pos.X + dx * normalize;
            int targetY = piece.Pos.Y + dy * normalize;

            var app = AppData.GetInstance();
            // 盤外ならスキップ
            if (targetX < 0 || targetX >= app.MapWidth || targetY < 0 || targetY >= app.MapHeight) {
                continue;
            }

            var next = new Position(targetX, targetY);

            var units = UnitManager.GetInstance();
            var previous = units.GetUnitAtPosition(next);

            if (previous is null || previous.Group != piece.Group) {
                yield return next;
            }
        }
    }
}