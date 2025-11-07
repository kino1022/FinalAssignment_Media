namespace FinalAssignment.MoveRule;

public class GoldGeneralRule : AMoveRule {

    public GoldGeneralRule() : base(new (int vertical, int horizontal)[] {
        (1, 0), // 前
        (0, -1), // 左
        (0, 1), // 右
        (-1, 0), // 後
        (1, -1), // 前左斜め
        (1, 1) // 前右斜め
    }) {
        
    }
}