namespace FinalAssignment.MoveRule;

public enum SlideDirection {
    RightFront,
    RightBack,
    LeftFront,
    LeftBack
}

public class SlideMove : IMoveRule {

    private SlideDirection _dir;
    
    private int _length;
    
    public SlideMove(SlideDirection dir, int length) {
        _dir = dir;
        _length = length;
    }
    
    public IEnumerable<Position> GetMoves(APiece piece) {

        var units = UnitManager.GetInstance();
        
        var normalizedDir = (int)piece.Group;
        
        var dir = _dir.ToVector();
        //スライド方向をグループによって変更
        dir.vertical *= normalizedDir;
        dir.horizontal *= normalizedDir;

        var pos = piece.Pos;

        for (int step = 0; step < _length + 1; step++) {
            var next = pos + new Position(dir.vertical, dir.horizontal);

            //版内でなければそこで終了
            if (next.IsInside()) {
                break;
            }
            
            //次の位置にいるユニットを取得
            var previous = units.GetUnitAtPosition(next);
            
            //ユニットがいなければそのまま追加
            if (previous is null) {
                yield return next;
                continue;
            }
            else if (previous is not null && previous.Group != piece.Group) {
                yield return next;
            }

            break;
        }
        
    }
}

public static class SlideDirectionExtension {
    public static (int vertical, int horizontal) ToVector(this SlideDirection dir) {
        return dir switch {
            SlideDirection.RightFront => (1, 1),
            SlideDirection.RightBack => (-1, 1),
            SlideDirection.LeftFront => (1, -1),
            SlideDirection.LeftBack => (-1, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };
    }
}