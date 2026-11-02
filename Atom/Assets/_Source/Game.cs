using System;

namespace _Source
{
  public class Game
  {
    private static Game _instance;
    public static Game Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new Game();
        }
        return _instance;
      }
    }

    public bool IsPlaying { get; private set; }
    
    public event Action OnGameStarted;
    public event Action OnGameLost;

    public void StartGame()
    {
      IsPlaying = true;
      OnGameStarted?.Invoke();
    }

    public void OnDecayTimerEnded()
    {
      if (!IsPlaying) return;
        
      Lose();
    }

    private void Lose()
    {
      IsPlaying = false;
      OnGameLost?.Invoke();
    }
  }
}