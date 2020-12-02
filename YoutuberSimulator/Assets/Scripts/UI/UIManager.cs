using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : UIObject
{
    private EventsController _eventsController { get { return EventsController.Instance; } }

    public UIEventPanel EventPanel;
    
    public override void RefreshObject()
    {
        if (_eventsController.EventReady)
        {
            _eventsController.EventShown();
            ShowEvent();
        }
    }

    void ShowEvent()
    {
        EventPanel.SetEvent(_eventsController.GetEventDescription());
        EventPanel.gameObject.SetActive(true);
    }
}
