using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    GameManager _gameManager;
    PlayerManager _playerManager;
    ActionsManager _actionsManager;
    ChatData _chatData;

    public event System.Action OnGameRestart;

    public void Init(GameManager gameManager, PlayerManager playerManager, ChatData chatData, ActionsManager actionsManager)
    {
        _gameManager = gameManager;
        _chatData = chatData;
        _playerManager = playerManager;
        _actionsManager = actionsManager;
        _gameManager.OnTickTimer += HandleTick;
    }

    void HandleTick()
    {
        if (_actionsManager.CurrentAction != ActionType.Streaming) return;

        _chatData.GameTicks++;

        if(_chatData.GameTicks >= _chatData.TickTresholds[_playerManager.PlayerLevel()])
        {
            _chatData.GameTicks = 0;
            SpawnMessage();
        }
    }

    void SpawnMessage()
    {
        var messegeType = GetMessageType();
        string content;

        switch (messegeType)
        {
            case MessegeType.Negative:
                content = GameTranslate.GetTranslation("NEGATIVE" + Random.Range(0, _chatData.NegativeTexts.Length).ToString());
                break;
            case MessegeType.Neutral:
                content = GameTranslate.GetTranslation("NEUTRAL" + Random.Range(0, _chatData.NeutralTexts.Length).ToString());
                break;
            case MessegeType.Positive:
                content = GameTranslate.GetTranslation("POSITIVE" + Random.Range(0, _chatData.PositiveTexts.Length).ToString());
                break;
            case MessegeType.Hatefull:
                content = _playerManager.Girl ?
                    GameTranslate.GetTranslation("GIRLHATEFULL" + Random.Range(0, _chatData.GirlHatefullTexts.Length).ToString())
                    : GameTranslate.GetTranslation("BOYHATEFULL" + Random.Range(0, _chatData.BoyHatefullTexts.Length).ToString());
                break;
            default:
                content = "";
                break;
        }

        _chatData.MessageToDisplay = new ChatMessage
        {
            Type = messegeType,
            Content = content
        };

        _playerManager.HandleMessage(_chatData.MessageToDisplay);
    }

    MessegeType GetMessageType()
    {
        var chance = _chatData.NegativeChance + _chatData.NeutralChance + _chatData.PositiveChance;
        var messageRoll = Random.Range(0, chance);
        var hatefullRoll = Random.Range(0, 101);

        if (hatefullRoll <= _chatData.HatefullChance)
        {
            return MessegeType.Hatefull;
        }

        if (messageRoll <= _chatData.PositiveChance)
        {
            return MessegeType.Positive;
        }
        else if(messageRoll <= _chatData.PositiveChance + _chatData.NegativeChance)
        {
            return MessegeType.Negative;
        }
        else
        {
            return MessegeType.Neutral;
        }
    }

    public void GameRestarted()
    {
        OnGameRestart();
    }

    public void AddPositiveChance(int amount)
    {
        _chatData.PositiveChance += amount;
    }

    public void AddNegativeChance(int amount)
    {
        _chatData.NegativeChance += amount;
    }

    public void AddHatefullChance(float amount)
    {
        _chatData.HatefullChance += amount;
    }

    public ChatMessage DisplayMessage()
    {
        var message = _chatData.MessageToDisplay;
        _chatData.MessageToDisplay = null;

        return message;
    }

    public bool IsMessageToBeDisplayed => _chatData.MessageToDisplay != null;
    public float HatefullChance => _chatData.HatefullChance;
}

public enum MessegeType
{
    Negative,
    Neutral,
    Positive,
    Hatefull
}
