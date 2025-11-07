namespace FinalAssignment.MoveRule;

public enum MoveDirection {
    Front,
    FrontRight,
    Right,
    BackRight,
    Back,
    BackLeft,
    Left,
    FrontLeft
}

public static class MoveDirectionExtensions {
    public static (int x, int y) ToVector(this MoveDirection direction) {
        return direction switch {
            MoveDirection.Front => (0, 1),
            MoveDirection.FrontRight => (-1, 1),
            MoveDirection.Right => (-1, 0),
            MoveDirection.BackRight => (-1, -1),
            MoveDirection.Back => (0, -1),
            MoveDirection.BackLeft => (1,- 1),
            MoveDirection.Left => (1, 0),
            MoveDirection.FrontLeft => (1, 1),
            _ => (0, 0)
        };
    }
}