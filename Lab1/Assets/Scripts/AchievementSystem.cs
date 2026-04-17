using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    [SerializeField] private VoidEventChannel voidChannel;
    [SerializeField] private GameDataEventChannel gameDataChannel;
  
    private void OnEnable()
    {
        EventChannelManager.Instance.voidEvent.OnEventRaised += EventCalled;
    }

    private void OnDisable()
    {
        EventChannelManager.Instance.voidEvent.OnEventRaised -= EventCalled;

    }

    private void EventCalled()
    {
        Debug.Log("Event Called by listening to the Event Channel of Void type");
    }
}