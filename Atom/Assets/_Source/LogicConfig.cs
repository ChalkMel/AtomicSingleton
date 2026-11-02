using UnityEngine;

namespace _Source
{
  [CreateAssetMenu(fileName = "Logic", menuName = "Reactor/Logic Config")]
  public class LogicConfig : ScriptableObject
  {
    public ResourceTimings[] Timings;
  }
  [System.Serializable]
  public class ResourceTimings
  {
    public ResourceType Type;
    public float EnrichmentTime;
    public float DecayTime;
  }
}