using System;

namespace FinalAssignment;

public enum Group {
    
    Red = -1,
    
    Blue = 1
}

public static class GroupExtensions {
    
    public static System.ConsoleColor ToColor(this Group group) {
        return group switch {
            Group.Red => ConsoleColor.Red,
            Group.Blue => ConsoleColor.Blue,
            _ => ConsoleColor.Black
        };
    }
    
}