namespace FinalAssignment;

public sealed class AppData {

    public int MapWidth = 20;
    
    public int MapHeight = 20;

    public int DrawTop = 0;
    
    private static AppData Instance = new AppData();
    
    public static AppData GetInstance() => Instance;
}