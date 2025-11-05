namespace FinalAssignment;

public interface IBackGroundDrawer
{
    
    void UpdateDraw();
}

public class BackGroundDrawer : IBackGroundDrawer
{

    private static IBackGroundDrawer _instance = new BackGroundDrawer();
        
    private readonly IBackGroundContainer _container = BackGroundContainer.GetInstance();
    
    private readonly AppData _app = AppData.GetInstance();
    
    public static IBackGroundDrawer GetInstance() => _instance;

    public void UpdateDraw()
    {
        for (int y = 0; y < _app.MapHeight; y++)
        {
            for (int x = 0; x < _app.MapWidth; x++)
            {
                if (_container.Colors.TryGetValue(new Position(x, y), out var color))
                {
                    //この+1はDrawManagerのMessageInfo分
                    Console.SetCursorPosition(x, y + 1);
                    
                    Console.ForegroundColor = color;
                }
            }
        }
    }

}