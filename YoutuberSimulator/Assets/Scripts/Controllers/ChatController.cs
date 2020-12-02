using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatController : MonoBehaviour
{
    private ChatManager _manager;

    public static ChatController Instance;

    private void Awake()
    {
        _manager = FindObjectOfType<ChatManager>();
        _manager.OnGameRestart += CallEvent;
        Instance = this;
    }

    public bool IsMessageToBeDisplayed => _manager.IsMessageToBeDisplayed;
    public float HatefullChance => _manager.HatefullChance;

    public ChatMessage DisplayMessage => _manager.DisplayMessage();
    public void CallEvent() => CallGameRestarted();
    public event System.Action CallGameRestarted;
}
