namespace _Source
{
  using System;
  using System.Collections;
  using UnityEngine;

  public class TimerService : MonoBehaviour
  {
    private static TimerService _instance;
    public static TimerService Instance => _instance;

    private void Awake()
    {
      if (_instance == null) _instance = this;
      else Destroy(gameObject);
    }

    public Coroutine StartTimer(float duration, Action onComplete)
    {
      return StartCoroutine(TimerRoutine(duration, onComplete));
    }

    public void StopTimer(Coroutine timer)
    {
      if (timer != null) StopCoroutine(timer);
    }

    private IEnumerator TimerRoutine(float duration, Action onComplete)
    {
      yield return new WaitForSeconds(duration);
      onComplete?.Invoke();
    }
  }
}