using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Objects/Game Data")]
public class GameData : ScriptableObject
{
    public float GameTimer;
    public float CurrentTimer;
    public bool GameStarted;

    public int TicksForEvent;
    public int NextEventAtTicks;
    public bool EventReady;

    public EventData CurrentEvent;

    public EventData[] StreamingEvents;
    public EventData[] OutsideEvents;
    public EventData[] CommentsEvent;
}
