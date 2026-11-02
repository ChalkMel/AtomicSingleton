using TMPro;
using UnityEngine;

namespace _Source
{
  public class GameTimer : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _recordText;
    
    private float _currentTime;
    private bool _isRunning;
    private float _recordTime;
    private const string record_time_key = "RecordTime";
    private const float divider = 60f;

    public void StartTimer()
    {
      _currentTime = 0f;
      _isRunning = true;
      
      _recordTime = PlayerPrefs.GetFloat(record_time_key);
      if (_recordTime > 0f)
        _recordText.text = "Best: " + FormatTime(_recordTime);
    }

    public void StopTimer()
    {
      _isRunning = false;
      if (_currentTime > _recordTime)
        PlayerPrefs.SetFloat(record_time_key, _currentTime);
    }

    private void Update()
    {
      if (!_isRunning) return;

      _currentTime += Time.deltaTime;
      _timerText.text = FormatTime(_currentTime);
    }

    private string FormatTime(float time)
    {
      int minutes = Mathf.FloorToInt(time / divider);
      int seconds = Mathf.FloorToInt(time % divider);
      return $"{minutes:00}:{seconds:00}";
    }
  }
}