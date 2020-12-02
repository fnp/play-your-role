using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    PlayerData _playerData;

    public void Init(PlayerData playerData)
    {
        _playerData = playerData;
    }

    public void SetAction(ActionType type)
    {
        _playerData.CurrentAction = type;
    }

    public ActionType CurrentAction => _playerData.CurrentAction; 
}

public enum ActionType
{
    Streaming,
    Watching,
    Responding,
    Walking,
    Friends
}
