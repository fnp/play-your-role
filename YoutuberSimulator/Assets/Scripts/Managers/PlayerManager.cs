using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameManager _gameManager;
    ActionsManager _actionsManager;
    PlayerData _playerData;
    ChatManager _chatManager;

    public void Init(PlayerData playerData, GameManager gameManager, ActionsManager actionsManager, ChatManager chatManager)
    {
        _playerData = playerData;
        _gameManager = gameManager;
        _actionsManager = actionsManager;
        _chatManager = chatManager;
        _gameManager.OnTickTimer += HandleTick;
    }

    public void SetGender(bool girl)
    {
        _playerData.Girl = girl;
    }

    public int PlayerLevel()
    {
        for (int i = 0; i < _playerData.SubsTresholds.Length; i++)
        {
            if (_playerData.Subs < _playerData.SubsTresholds[i]) return i;
        }

        return 0;
    }

    public void HandleMessage(ChatMessage chatMessage)
    {
        switch (chatMessage.Type)
        {
            case MessegeType.Negative:
                AddStress(8f);
                break;
            case MessegeType.Neutral:
                break;
            case MessegeType.Positive:
                AddPassion(5);
                break;
            case MessegeType.Hatefull:
                AddStress(10f);
                AddPassion(-5f);
                break;
        };
    }

    public void RestartGame()
    {
        _gameManager.RestartGame();

        _chatManager.GameRestarted();
    }

    public string GameOver()
    {
        _gameManager.GameOver();
        return EndGameDescription();
    }

    public string EndGameDescription()
    {
        if(_playerData.Subs > 10000)
        {
            return GameTranslate.GetTranslation("ENDGAME4");
        }
        else if(_playerData.Subs > 2000)
        {
            return GameTranslate.GetTranslation("ENDGAME3");
        }
        else if(_playerData.Stress >= 100)
        {
            return GameTranslate.GetTranslation("ENDGAME2");
        }
        else
        {
            return GameTranslate.GetTranslation("ENDGAME1");
        }
    }

    void HandleTick()
    {
        switch (_actionsManager.CurrentAction)
        {
            case ActionType.Streaming:
                AddSubs(PlayerLevel() + 3);
                _chatManager.AddHatefullChance(0.06f);
                break;
            case ActionType.Friends:
                AddPassion(-0.8f);
                AddStress(-2.8f);
                AddSubs(-(PlayerLevel()/2));
                break;
            case ActionType.Walking:
                AddPassion(-2.0f);
                AddStress(-4.0f);
                AddSubs(-(PlayerLevel()/2));
                break;
            case ActionType.Watching:
                AddPassion(0.2f);
                AddStress(-1.0f);
                AddSubs(-(PlayerLevel()/4));
                break;
            case ActionType.Responding:
                AddPassion(1f);
                AddStress(1f);
                _chatManager.AddHatefullChance(-0.3f);
                AddSubs(PlayerLevel());
                break;
        };
    }

    public void AddSubs(int value)
    {
        _playerData.Subs += value;

        if(_playerData.Subs < 0)
        {
            _playerData.Subs = 0;
        }
    }

    public void AddPassion(float value)
    {
        _playerData.Passion += value;
        _playerData.Passion = Mathf.Clamp(_playerData.Passion, 0f, 100f);
    }

    public void AddStress(float value)
    {
        _playerData.Stress += value;
        _playerData.Stress = Mathf.Clamp(_playerData.Stress, 0f, 100f);
    }

    public float Passion => _playerData.Passion;
    public float Stress => _playerData.Stress;
    public int Subs => _playerData.Subs;
    public bool Girl => _playerData.Girl;
}
