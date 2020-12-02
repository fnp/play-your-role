using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    GameManager _gameManager;
    ActionsManager _actionsManager;
    PlayerManager _playerManager;
    ChatManager _chatManager;
    GameData _gameData;

    List<EventData> StreamingEvents;
    List<EventData> OutsideEvents;
    List<EventData> CommentsEvents;

    public event System.Action OnTickTimer;

    public void Init(GameManager gameManager, GameData gameData, ActionsManager actionsManager, PlayerManager playerManager, ChatManager chatManager)
    {
        _gameManager = gameManager;
        _actionsManager = actionsManager;
        _playerManager = playerManager;
        _chatManager = chatManager;
        _gameData = gameData;
        _gameManager.OnTickTimer += HandleTick;

        StreamingEvents = new List<EventData>();
        StreamingEvents.AddRange(_gameData.StreamingEvents);

        OutsideEvents = new List<EventData>();
        OutsideEvents.AddRange(_gameData.OutsideEvents);

        CommentsEvents = new List<EventData>();
        CommentsEvents.AddRange(_gameData.CommentsEvent);

        _gameData.NextEventAtTicks = Random.Range(60, 80);
    }

    void HandleTick()
    {
        _gameData.TicksForEvent++;

        if(_gameData.TicksForEvent >= _gameData.NextEventAtTicks)
        {
            _gameData.TicksForEvent = 0;
            _gameData.NextEventAtTicks = Random.Range(60, 80);
            CreateEvent();
        }
    }

    void CreateEvent()
    {
        switch (_actionsManager.CurrentAction)
        {
            case ActionType.Streaming:
                if(StreamingEvents.Count == 0) StreamingEvents.AddRange(_gameData.StreamingEvents);
                _gameData.CurrentEvent = GetRandomEvent(StreamingEvents);
                _gameData.EventReady = true;
                break;
            case ActionType.Watching:
                if (CommentsEvents.Count == 0) CommentsEvents.AddRange(_gameData.CommentsEvent);
                _gameData.CurrentEvent = GetRandomEvent(StreamingEvents);
                _gameData.EventReady = true;
                break;
            case ActionType.Responding:
                if (CommentsEvents.Count == 0) CommentsEvents.AddRange(_gameData.CommentsEvent);
                _gameData.CurrentEvent = GetRandomEvent(CommentsEvents);
                _gameData.EventReady = true;
                break;
            case ActionType.Walking:
                if (OutsideEvents.Count == 0) OutsideEvents.AddRange(_gameData.OutsideEvents);
                _gameData.CurrentEvent = GetRandomEvent(OutsideEvents);
                _gameData.EventReady = true;
                break;
            case ActionType.Friends:
                if (OutsideEvents.Count == 0) OutsideEvents.AddRange(_gameData.OutsideEvents);
                _gameData.CurrentEvent = GetRandomEvent(OutsideEvents);
                _gameData.EventReady = true;
                break;
        }
    }

    EventData GetRandomEvent(List<EventData> eventsList)
    {
        var index = Random.Range(0, eventsList.Count);
        var pickedEvent = eventsList[index];
        eventsList.RemoveAt(index);
        return pickedEvent;
    }

    public void OptionOneSelected()
    {
        switch (_gameData.CurrentEvent.OptionOneType1)
        {
            case ModifierType.Subs:
                _playerManager.AddSubs((int)_gameData.CurrentEvent.OptionOneAmount1);
                break;
            case ModifierType.Stress:
                _playerManager.AddStress(_gameData.CurrentEvent.OptionOneAmount1);
                break;
            case ModifierType.Passion:
                _playerManager.AddPassion(_gameData.CurrentEvent.OptionOneAmount1);
                break;
            case ModifierType.PositiveComments:
                _chatManager.AddPositiveChance((int)_gameData.CurrentEvent.OptionOneAmount1);
                break;
            case ModifierType.NegativeComments:
                _chatManager.AddNegativeChance((int)_gameData.CurrentEvent.OptionOneAmount1);
                break;
            case ModifierType.HatefullComments:
                _chatManager.AddHatefullChance((int)_gameData.CurrentEvent.OptionOneAmount1);
                break;
        }

        switch (_gameData.CurrentEvent.OptionOneType2)
        {
            case ModifierType.Subs:
                _playerManager.AddSubs((int)_gameData.CurrentEvent.OptionOneAmount2);
                break;
            case ModifierType.Stress:
                _playerManager.AddStress(_gameData.CurrentEvent.OptionOneAmount2);
                break;
            case ModifierType.Passion:
                _playerManager.AddPassion(_gameData.CurrentEvent.OptionOneAmount2);
                break;
            case ModifierType.PositiveComments:
                _chatManager.AddPositiveChance((int)_gameData.CurrentEvent.OptionOneAmount2);
                break;
            case ModifierType.NegativeComments:
                _chatManager.AddNegativeChance((int)_gameData.CurrentEvent.OptionOneAmount2);
                break;
            case ModifierType.HatefullComments:
                _chatManager.AddHatefullChance((int)_gameData.CurrentEvent.OptionOneAmount2);
                break;
        }

        _gameManager.EventCompleted();
    }

    public void OptionTwoSelected()
    {
        switch (_gameData.CurrentEvent.OptionTwoType1)
        {
            case ModifierType.Subs:
                _playerManager.AddSubs((int)_gameData.CurrentEvent.OptionTwoAmount1);
                break;
            case ModifierType.Stress:
                _playerManager.AddStress(_gameData.CurrentEvent.OptionTwoAmount1);
                break;
            case ModifierType.Passion:
                _playerManager.AddPassion(_gameData.CurrentEvent.OptionTwoAmount1);
                break;
            case ModifierType.PositiveComments:
                _chatManager.AddPositiveChance((int)_gameData.CurrentEvent.OptionTwoAmount1);
                break;
            case ModifierType.NegativeComments:
                _chatManager.AddNegativeChance((int)_gameData.CurrentEvent.OptionTwoAmount1);
                break;
            case ModifierType.HatefullComments:
                _chatManager.AddHatefullChance((int)_gameData.CurrentEvent.OptionTwoAmount1);
                break;
        }

        switch (_gameData.CurrentEvent.OptionTwoType2)
        {
            case ModifierType.Subs:
                _playerManager.AddSubs((int)_gameData.CurrentEvent.OptionTwoAmount2);
                break;
            case ModifierType.Stress:
                _playerManager.AddStress(_gameData.CurrentEvent.OptionTwoAmount2);
                break;
            case ModifierType.Passion:
                _playerManager.AddPassion(_gameData.CurrentEvent.OptionTwoAmount2);
                break;
            case ModifierType.PositiveComments:
                _chatManager.AddPositiveChance((int)_gameData.CurrentEvent.OptionTwoAmount2);
                break;
            case ModifierType.NegativeComments:
                _chatManager.AddNegativeChance((int)_gameData.CurrentEvent.OptionTwoAmount2);
                break;
            case ModifierType.HatefullComments:
                _chatManager.AddHatefullChance((int)_gameData.CurrentEvent.OptionTwoAmount2);
                break;
        }

        _gameManager.EventCompleted();
    }

    public void EventShown()
    {
        _gameManager.EventShown();
        _gameData.EventReady = false;
    }
    
    public (string description, string optionOne, string optionTwo) GetEventDescription()
    {
        return (_gameData.CurrentEvent.Description, _gameData.CurrentEvent.OptionOneDescription, _gameData.CurrentEvent.OptionTwoDescription);
    }
    
    public bool IsEventReady => _gameData.EventReady;
}
