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

        while (app.LoopFlag) {
            
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
        
        var silverA = new SilverGeneral(new Position(2, app.MapHeight -1), Group.Red);
        redPieces.Add(silverA);
        
        var silverB = new SilverGeneral(new  Position(6, app.MapHeight -1), Group.Red);
        redPieces.Add(silverB);
        
        var rook = new Rook(new Position(7, app.MapHeight -2), Group.Red);
        redPieces.Add(rook);
        
        var bishop = new Bishop(new Position(1, app.MapHeight -2), Group.Red);
        redPieces.Add(bishop);
        
        var lancerA = new Lancer(new Position(0, app.MapHeight -1), Group.Red);
        redPieces.Add(lancerA);
        
        var lancerB = new Lancer(new Position(8, app.MapHeight -1), Group.Red);
        redPieces.Add(lancerB);
        
        var knightA = new Knight(new Position(1, app.MapHeight -1), Group.Red);
        redPieces.Add(knightA);
        
        var knightB = new Knight(new Position(7,  app.MapHeight -1), Group.Red);
        redPieces.Add(knightB);
        
        var king = new King(new  Position(4, app.MapHeight -1), Group.Red);
        redPieces.Add(king);
    }

    private static void InitBluePieces() {
        bluePieces.Clear();
        
        for (int i = 0; i < app.MapWidth; i++) {
            var pawn = new Pawn(new Position(i, 2), Group.Blue);
            bluePieces.Add(pawn);
        }
        
        var goldA = new GoldGeneral(new Position(3, 0), Group.Blue);
        bluePieces.Add(goldA);
        
        var goldB = new GoldGeneral(new  Position(5, 0), Group.Blue);
        bluePieces.Add(goldB);
        
        var silverA = new SilverGeneral(new Position(2, 0), Group.Blue);
        bluePieces.Add(silverA);
        
        var silverB = new SilverGeneral(new  Position(6, 0), Group.Blue);
        bluePieces.Add(silverB);
        
        var rook = new Bishop(new Position(7, 1), Group.Blue);
        bluePieces.Add(rook);
        
        var bishop = new Rook(new Position(1, 1), Group.Blue);
        bluePieces.Add(bishop);
        
        var lancerA = new Lancer(new Position(0, 0), Group.Blue);
        bluePieces.Add(lancerA);
        
        var lancerB = new Lancer(new Position(8, 0), Group.Blue);
        bluePieces.Add(lancerB);
        
        var knightA = new Knight(new Position(1, 0), Group.Blue);
        redPieces.Add(knightA);
        
        var knightB = new Knight(new Position(7,  0), Group.Blue);
        redPieces.Add(knightB);
        
        var king = new King(new  Position(4, 0), Group.Blue);
        bluePieces.Add(king);
    }
}