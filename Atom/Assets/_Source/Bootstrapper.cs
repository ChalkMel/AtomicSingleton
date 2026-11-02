using UnityEngine;

namespace _Source
{
  public class Bootstrapper : MonoBehaviour
  {
    [SerializeField] private GameView _gameView;

    private void Awake()
    {
      var displayService = DisplayService.Instance;
      var dataService = DataService.Instance;
    }

    private void Start()
    {
      _gameView.Initialize();
      Game.Instance.StartGame();
    }
  }
}