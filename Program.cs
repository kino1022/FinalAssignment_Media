using FinalAssignment;

class Program {
    
    private static AppData app = AppData.GetInstance();

    private static List<IPiece> redPieces = new List<IPiece>() {
        new Piece('歩', new Position(0, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(1, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(2, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(3, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(4, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(5, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(6, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(7, app.MapHeight - 3), Group.Red),
        new Piece('歩', new Position(8, app.MapHeight - 3), Group.Red),
 
    };
    
    private static List<IPiece> bluePieces = new List<IPiece>() {
        new Piece('歩', new Position(0, 2), Group.Blue),
        new Piece('歩', new Position(1, 2), Group.Blue),
        new Piece('歩', new Position(2, 2), Group.Blue),
        new Piece('歩', new Position(3, 2), Group.Blue),
        new Piece('歩', new Position(4, 2), Group.Blue),
        new Piece('歩', new Position(5, 2), Group.Blue),
        new Piece('歩', new Position(6, 2), Group.Blue),
        new Piece('歩', new Position(7, 2), Group.Blue),
        new Piece('歩', new Position(8, 2), Group.Blue),
    };

    static void Main(string[] args) {

        var units = new UnitManager<IPiece>();
        
        var drawManager = new DrawManager(units);
        
        redPieces.ForEach(x => units.AddUnit(x));
        
        bluePieces.ForEach(x => units.AddUnit(x));
            
        while (true) {
            drawManager.UpdateDraw();
            
            System.Threading.Thread.Sleep(1000);
        }
    }
}