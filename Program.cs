using FinalAssignment;
using FinalAssignment.Cursor;
using FinalAssignment.Input;
using FinalAssignment.State;

class Program {

    #region  Singleton Objects
    
    private static AppData app = AppData.GetInstance();
    
    private static IDrawManager _drawer = DrawManager.GetInstance();
    
    private static IUnitManager<APiece> _units = UnitManager.GetInstance(); 
    
    private static GameStateManager _state = GameStateManager.GetInstance();

    private static IPlayerCursor _cursor = PlayerCursor.GetInstance();
    
    private static IInputManager _input = InputManager.GetInstance();
    
    #endregion
    
    private static List<APiece> redPieces = new List<APiece>() {
 
    };
    
    private static List<APiece> bluePieces = new List<APiece>() {
        
    };

    static void Main(string[] args) {
        
        
        InitReadPieces();
        
        InitBluePieces();
        
        redPieces.ForEach(x => _units.AddUnit(x));
        
        bluePieces.ForEach(x => _units.AddUnit(x));
        
        _state.CurrentState.Enter();

        Console.CursorVisible = false;

        while (true) {
            
            while (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                _input.Queue.Enqueue(keyInfo);
            }
            
            _state.Update();
            
            _drawer.UpdateDraw();
            

            Thread.Sleep(50);
        }
    }
    
    private static void InitReadPieces() {
        redPieces.Clear();

        for (int i = 0; i < app.MapWidth; i++) {
            var pawn = new Pawn(new Position(i, app.MapHeight -3), Group.Red);
            redPieces.Add(pawn);
        }

        var goldA = new GoldGeneral(new Position(3, app.MapHeight -1), Group.Red);
        redPieces.Add(goldA);
        
        var goldB = new GoldGeneral(new  Position(5, app.MapHeight -1), Group.Red);
        redPieces.Add(goldB);
    }

    private static void InitBluePieces() {
        bluePieces.Clear();
        
        for (int i = 0; i < app.MapWidth; i++) {
            var pawn = new Pawn(new Position(i, 2), Group.Blue);
            bluePieces.Add(pawn);
        }
        
    }
}