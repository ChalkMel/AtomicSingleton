using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Source
{
  public class GameView : MonoBehaviour
  {
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private ButtonSpawner _buttonSpawner;

   public void Initialize()
    {
      Game.Instance.OnGameStarted += HandleGameStarted;
      Game.Instance.OnGameLost += HandleGameLost;
      _restartButton.onClick.AddListener(RestartGame);

      _losePanel.SetActive(false);
      _buttonSpawner.DrawButtons();
    }
   
    private void OnDestroy()
    {
      Game.Instance.OnGameStarted -= HandleGameStarted;
      Game.Instance.OnGameLost -= HandleGameLost;
    }

    private void HandleGameStarted()
    {
      _gameTimer.StartTimer();
    }

    private void HandleGameLost()
    {
      _gameTimer.StopTimer();
      _losePanel.SetActive(true);
    }

    public void RestartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}