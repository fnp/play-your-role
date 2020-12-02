using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerManager _playerManager;
    GameData _gameData;
    StartupManager _startupManager;
    
    public event System.Action OnTickTimer;

    public void Init(StartupManager startupManager, PlayerManager playerManager, GameData gameData)
    {
        _startupManager = startupManager;
        _playerManager = playerManager;
        _gameData = gameData;
    }

    public void StartGame(bool girl)
    {
        _playerManager.SetGender(girl);
        _gameData.GameStarted = true;
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }

    public void RestartGame()
    {
        _startupManager.RestartGame();
        _gameData.GameStarted = true;
    }

    public void GameOver()
    {
        _gameData.GameStarted = false;
    }

    public void EventShown()
    {
        _gameData.GameStarted = false;
    }

    public void EventCompleted()
    {
        _gameData.GameStarted = true;
    }

    private void Update()
    {
        if (_gameData.GameStarted)
        {
            _gameData.CurrentTimer += Time.deltaTime;

            if(_gameData.CurrentTimer >= _gameData.GameTimer)
            {
                _gameData.CurrentTimer = 0;
                OnTickTimer();
            }
        }
    }
}
