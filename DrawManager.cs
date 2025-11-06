using FinalAssignment.Cursor;

namespace FinalAssignment;

public interface IDrawManager {
    
    string InfoMessage { get; set; }
    
    string DebugMessage { get; set; }

    /// <summary>
    /// 描画状態の更新を行う
    /// </summary>
    void UpdateDraw();
    
}

public sealed class DrawManager : IDrawManager {
    
    private static IDrawManager _instance = new DrawManager();
    
    private AppData m_appData = AppData.GetInstance();

    private IUnitManager<APiece> m_units = UnitManager.GetInstance();

    private readonly IBackGroundContainer _bg = BackGroundContainer.GetInstance();
    
    private readonly char emptySymbol = '・';

    public string InfoMessage { get; set; } = string.Empty;
    
    public string DebugMessage { get; set; } = string.Empty;
    
    private readonly IPlayerCursor _cursor = FinalAssignment.Cursor.PlayerCursor.GetInstance();

    public static IDrawManager GetInstance() => _instance;
    

    public void UpdateDraw() {
        try {
            Console.Clear();

            // InfoMessage は一番上に固定
            Console.SetCursorPosition(0, m_appData.DrawTop);
            Console.WriteLine(InfoMessage);

            // セル幅（表示カラム数）を固定。全角文字が幅2で表示される端末向けに2を使う。
            int cellWidth = 2;

            // ボードは行ごとに、各マスをセル幅で描画する
            for (int y = 0; y < m_appData.MapHeight; y++) {
                var cursorY = m_appData.DrawTop + 1 + y;

                for (int x = 0; x < m_appData.MapWidth; x++) {
                    var pos = new Position(x, y);
                    var unit = m_units.GetUnitAtPosition(pos);

                    // カーソルとセルの左上に移動
                    int drawX = x * cellWidth;
                    try { Console.SetCursorPosition(drawX, cursorY); } catch { /* 失敗しても続行 */ }

                    var isCursor = _cursor.Position.X == x && _cursor.Position.Y == y;

                    // 背景色設定
                    if (_bg.Colors.TryGetValue(pos, out var bgColor)) {
                        Console.BackgroundColor = bgColor;
                    } else {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    if (isCursor) {
                        // カーソルがあるマスは反転表示
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (unit != null) Console.Write(unit.Symbol);
                        else Console.Write(emptySymbol);
                        // もしセル幅が2なら右隣にスペースで埋める（全角で2幅の場合は不要だが安全策）
                        if (cellWidth > 1) Console.Write(' ');
                        Console.ResetColor();
                        continue;
                    }

                    // 前景色と文字
                    if (unit != null) {
                        Console.ForegroundColor = unit.Group.ToColor();
                        Console.Write(unit.Symbol);
                    } else {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(emptySymbol);
                    }

                    // セル幅が2の場合は右隣に空白を出して列幅を揃える（半角端末では余分だが多くのターミナルで安定）
                    if (cellWidth > 1) Console.Write(' ');

                    Console.ResetColor();
                }
            }

            // 空行を1行挟んで DebugMessage を固定の下部に表示
            Console.WriteLine();

            // DebugMessage はマップの下、左端に表示
            var debugLine = m_appData.DrawTop + 1 + m_appData.MapHeight + 0;
            try {
                if (debugLine >= 0) Console.SetCursorPosition(0, debugLine);
            } catch {
                // コンソールの行数が足りない場合は SetCursorPosition をスキップしてそのまま出力する
            }
            Console.WriteLine(DebugMessage);
        }
        catch (Exception ex) {
            // 描画中の例外はアプリが見えなくなるので、最低限エラー文字列を出力しておく
            try {
                Console.Clear();
                Console.WriteLine("DrawManager failed: " + ex.Message);
            }
            catch { }
        }
    }
}