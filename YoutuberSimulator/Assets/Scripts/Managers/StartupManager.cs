using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    public string MainMenu;

    GameManager gameManager;
    DataProvider dataProvider;
    PlayerManager playerManager;
    ChatManager chatManager;
    ActionsManager actionsManager;
    EventsManager eventsManager;

    void Awake()
    {

        dataProvider = GetComponent<DataProvider>();
        CreateManagers();

        playerManager.Init(dataProvider.PlayerData, gameManager, actionsManager, chatManager);
        gameManager.Init(this, playerManager, dataProvider.GameData);
        actionsManager.Init(dataProvider.PlayerData);
        chatManager.Init(gameManager, playerManager, dataProvider.ChatData, actionsManager);
        eventsManager.Init(gameManager, dataProvider.GameData, actionsManager, playerManager, chatManager);

        ClearData();

        SceneManager.LoadScene(MainMenu, LoadSceneMode.Additive);
    }

    public void RestartGame()
    {
        ClearData();
    }

    void CreateManagers()
    {
        gameManager = (new GameObject("GameManager")).AddComponent<GameManager>();
        playerManager = (new GameObject("PlayerManager")).AddComponent<PlayerManager>();
        actionsManager = (new GameObject("ActionsManager")).AddComponent<ActionsManager>();
        chatManager = (new GameObject("ChatManager")).AddComponent<ChatManager>();
        eventsManager = (new GameObject("EventsManager")).AddComponent<EventsManager>();
    }

    void ClearData()
    {
        dataProvider.PlayerData.Passion = 30f;
        dataProvider.PlayerData.Stress = 0f;
        dataProvider.PlayerData.Subs = 0;
        dataProvider.ChatData.HatefullChance = 3f;
        dataProvider.GameData.TicksForEvent = 0;
        dataProvider.PlayerData.CurrentAction = ActionType.Streaming;
        dataProvider.GameData.GameStarted = false;
    }
}
