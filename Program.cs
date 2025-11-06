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

        while (true) {
            
            _drawer.UpdateDraw();

            Thread.Sleep(200);
        }
    }
    
    private static void InitReadPieces() {
        redPieces.Clear();

        for (int i = 0; i < app.MapWidth; i++) {
            var pawn = new Pawn(new Position(i, app.MapHeight -3), Group.Red);
            redPieces.Add(pawn);
        }
    }

    private static void InitBluePieces() {
        bluePieces.Clear();
        
        for (int i = 0; i < app.MapWidth; i++) {
            var pawn = new Pawn(new Position(i, 2), Group.Blue);
            bluePieces.Add(pawn);
        }
    }
}