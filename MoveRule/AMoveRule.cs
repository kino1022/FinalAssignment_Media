namespace FinalAssignment.MoveRule;

public abstract class AMoveRule : IMoveRule {

    private (int vertical, int horizontal)[] _destinations;
    
    protected AMoveRule((int vertical, int horizontal)[] destinations) {

        if (destinations.Length is 0) {
            throw new ArgumentOutOfRangeException(nameof(destinations));
        }
        
        _destinations = destinations;
    }
    
    public IEnumerable<Position> GetMoves (APiece piece) {
        
        var pos = piece.Pos;

        int directionMultiplier = (int)piece.Group;
        
        foreach (var moveRule in _destinations) {
            
            // ルールと Group から、実際の移動先を「計算」する
            var nextVertical = pos.Y + (moveRule.vertical * directionMultiplier);
            var nextHorizontal = pos.X + (moveRule.horizontal * directionMultiplier);

            var next = new Position(nextHorizontal, nextVertical);
            
            // 盤内かどうかだけチェックする
            if (next.IsInside()) {
                yield return next;
            }
            // 盤外なら yield break せず、単に無視して次の moveRule のチェックに進む
            // (else ブロックは不要)
        }
    }
    
    private bool IsInside (int x, int y, AppData app) {
        return x >= 0 && x < app.MapWidth && y >= 0 && y < app.MapHeight;
    }
}