using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    private EventsManager _manager;

    public static EventsController Instance;

    private void Awake()
    {
        _manager = FindObjectOfType<EventsManager>();
        Instance = this;
    }

    public (string description, string optionOne, string optionTwo) GetEventDescription() => _manager.GetEventDescription();
    public bool EventReady => _manager.IsEventReady;

    public void EventShown() => _manager.EventShown();
    public void OptionOneSelected() => _manager.OptionOneSelected();
    public void OptionTwoSelected() => _manager.OptionTwoSelected();
}
