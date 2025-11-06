namespace FinalAssignment;

public sealed class AppData {

    public int MapWidth = 9;
    
    public int MapHeight = 9;

    public int DrawTop = 0;

    public bool LoopFlag = true;
    
    private static AppData Instance = new AppData();
    
    public static AppData GetInstance() => Instance;
}