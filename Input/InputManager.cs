using System.Collections.Concurrent;

namespace FinalAssignment.Input;

public interface IInputManager {
    
    /// <summary>
    /// 入力されたキーのキュー
    /// </summary>
    ConcurrentQueue<ConsoleKeyInfo> Queue { get; }
    
}

public sealed class InputManager : IInputManager {
    
    private static readonly IInputManager _instance = new InputManager();
    
    private ConcurrentQueue<ConsoleKeyInfo> _queue = new ConcurrentQueue<ConsoleKeyInfo>();
    
    private readonly AppData _app = AppData.GetInstance();
    
    public ConcurrentQueue<ConsoleKeyInfo> Queue => _queue;
    
    public static IInputManager GetInstance() => _instance;
    
    private async Task InputCycle() {
        while (_app.LoopFlag) {
            if (Console.KeyAvailable) {
                var keyInfo = Console.ReadKey(true);
                _queue.Enqueue(keyInfo);
            }
            await Task.Delay(10);
        }
    }
    
}