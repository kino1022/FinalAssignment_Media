namespace FinalAssignment.MoveRule;

public interface IMoveRule {
    
    /// <summary>
    /// 移動可能な座標を取得する
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    IEnumerable<IPosition> GetMoves (IPiece piece);
    
}