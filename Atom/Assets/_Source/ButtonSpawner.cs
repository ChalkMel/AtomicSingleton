using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source
{
  public class ButtonSpawner: MonoBehaviour
  {
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonSpawnPoint;
    public void DrawButtons()
    {
      foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
      {
        ResourceButton newButton = Instantiate(_buttonPrefab, _buttonSpawnPoint).GetComponent<ResourceButton>();
        
        newButton.Initialize(type);
      }
    }
  }
}