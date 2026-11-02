using UnityEngine;

namespace _Source
{
  public class DataService
  {
    private static DataService _instance;
    private const string path = "LogicConfig";
    
    public static DataService Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new DataService();
          _instance.LoadData();
        }
        return _instance;
      }
    }

    private LogicConfig _database;

    private void LoadData()
    {
      _database = Resources.Load<LogicConfig>(path);
        
      if (_database == null)
        Debug.LogError("LogicDatabase не найден в папке Resources");
    }

    public ResourceTimings GetTimings(ResourceType type)
    {
      return System.Array.Find(_database.Timings, x => x.Type == type);
    }
  }
}