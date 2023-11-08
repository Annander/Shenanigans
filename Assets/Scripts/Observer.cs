using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private EventDemonstration eventDemonstration;

    private void Awake()
    {
        eventDemonstration.OnIntervalTick += ObserveTheThingThatHappened;
    }

    private void ObserveTheThingThatHappened(bool fancyBool)
    {
        Debug.Log("Observer totally got it: " + fancyBool);
    }
}