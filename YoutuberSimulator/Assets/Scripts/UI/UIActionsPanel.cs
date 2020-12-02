using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionsPanel : UIObject
{
    private ActionsController _actionsController { get { return ActionsController.Instance; } }
    
    public GameObject RelaxPanel;
    public GameObject OnlinePanel;


    public void SetAction(string actionName)
    {
        if(Enum.TryParse(actionName, out ActionType action))
        {
            _actionsController.SetAction(action);
        }
    }

    public override void RefreshObject()
    {

    }

    public void SwitchPanel()
    {
        RelaxPanel.SetActive(!RelaxPanel.activeSelf);
        OnlinePanel.SetActive(!OnlinePanel.activeSelf);
    } 
}
