using UnityEngine;

namespace _Source
{
  [CreateAssetMenu(fileName = "Visual", menuName = "Reactor/Visual Config")]
  public class VisualConfig : ScriptableObject
  {
    public ResourceVisual[] Resources;
  }
  
  [System.Serializable]
  public class ResourceVisual
  {
    public ResourceType Type;
    public Sprite InactiveSprite;
    public Sprite ActiveSprite;
  }
}