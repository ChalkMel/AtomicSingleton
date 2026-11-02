using UnityEngine;
using UnityEngine.UI;

namespace _Source
{
    [RequireComponent(typeof(Button))]
    public class ResourceButton : MonoBehaviour
    {
        private ResourceType _resourceType;
    
        private Button _button;
        private Image _buttonImage;

        private float _enrichmentTime;
        private float _decayTime;

        private Coroutine _activeTimer;


       public void Initialize(ResourceType resourceType)
        {
            _resourceType = resourceType;
            _button = GetComponent<Button>();
            _buttonImage = GetComponent<Image>();
            _button.onClick.AddListener(OnButtonClicked);
            var timings = DataService.Instance.GetTimings(_resourceType);
            _enrichmentTime = timings.EnrichmentTime;
            _decayTime = timings.DecayTime;
            
            StartDecayPhase();
        }

        private void OnButtonClicked()
        {
            if (!Game.Instance.IsPlaying) return;
            
            StartEnrichmentPhase();
        }

        private void StartDecayPhase()
        {
            _button.interactable = true;
            _buttonImage.sprite = DisplayService.Instance.GetActiveSprite(_resourceType);
            
            _activeTimer = TimerService.Instance.StartTimer(_decayTime, Game.Instance.OnDecayTimerEnded);
        }

        private void StartEnrichmentPhase()
        {
            TimerService.Instance.StopTimer(_activeTimer);

            _button.interactable = false;
            _buttonImage.sprite = DisplayService.Instance.GetInactiveSprite(_resourceType);
            
            _activeTimer = TimerService.Instance.StartTimer(_enrichmentTime, StartDecayPhase);
        }
    }
}