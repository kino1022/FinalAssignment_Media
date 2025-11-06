namespace FinalAssignment.State;

public class SelectDestinationPhase : IGameState {
    
    private readonly APiece _unit;
    
    private readonly IDrawManager _draw = DrawManager.GetInstance();

    public SelectDestinationPhase(APiece unit) {
        _unit = unit;
    }
    
    public void Enter() {
        _draw.InfoMessage = "移動先を選択してください";
    }

    public void Update() {
        
    }

    public void Exit() {
        
    }
}