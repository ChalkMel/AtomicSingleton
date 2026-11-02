using UnityEngine;

namespace _Source
{
  public class DisplayService
  {
    private static DisplayService _instance;
    private const string path = "VisualConfig";
    public static DisplayService Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new DisplayService();
          _instance.LoadData();
        }

        return _instance;
      }
    }

    private VisualConfig _database;

    private void LoadData()
    {
      _database = Resources.Load<VisualConfig>(path); 
        
      if (_database == null)
        Debug.LogError("VisualDatabase не найден в папке Resources");
    }

    public Sprite GetActiveSprite(ResourceType type)
    {
      var data = System.Array.Find(_database.Resources, x => x.Type == type);
      return data != null ? data.ActiveSprite : null;
    }

    public Sprite GetInactiveSprite(ResourceType type)
    {
      var data = System.Array.Find(_database.Resources, x => x.Type == type);
      return data != null ? data.InactiveSprite : null;
    }
  }
}