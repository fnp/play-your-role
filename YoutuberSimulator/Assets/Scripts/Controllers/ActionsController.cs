using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController : MonoBehaviour
{
    private ActionsManager _manager;

    public static ActionsController Instance;

    private void Awake()
    {
        _manager = FindObjectOfType<ActionsManager>();
        Instance = this;
    }

    public void SetAction(ActionType type) => _manager.SetAction(type);
    public ActionType CurrentAction => _manager.CurrentAction;
}
