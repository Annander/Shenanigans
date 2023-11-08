using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EventDemonstration : MonoBehaviour
{
    public event IntervalEvent OnIntervalTick;
    public delegate void IntervalEvent(bool fancyBool);
    
    [SerializeField] private UnityEvent unityEvent;
    
    [SerializeField] private float interval;

    private float _timer;

    private void OnEnable()
    {
        OnIntervalTick += EventThingThatTotallyHappens;
    }

    private void OnDisable()
    {
        OnIntervalTick -= EventThingThatTotallyHappens;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= interval)
        {
            _timer -= interval;
            
            // Event happens
            unityEvent.Invoke();
            
            GameManager.Instance.SwitchGameMode(GameMode.InGame);

            OnIntervalTick?.Invoke(Random.value <= .5f);
        }
    }

    public void EventThingThatTotallyHappens(bool fancyBool)
    {
        Debug.Log("Totally happened!" + fancyBool);
    }
}