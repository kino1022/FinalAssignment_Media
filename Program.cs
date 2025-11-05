using FinalAssignment;

class Program {
    
    private static AppData app = AppData.GetInstance();

    private static List<IPiece> redPieces = new List<IPiece>() {
 
    };
    
    private static List<IPiece> bluePieces = new List<IPiece>() {
        
    };

    static void Main(string[] args) {

        var units = new UnitManager<IPiece>();
        
        var drawManager = new DrawManager(units);

        InitReadPieces();
        
        InitBluePieces();
        
        redPieces.ForEach(x => units.AddUnit(x));
        
        bluePieces.ForEach(x => units.AddUnit(x));
            
        while (true) {
            drawManager.UpdateDraw();
            
           Thread.Sleep(1000);
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