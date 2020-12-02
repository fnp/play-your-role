using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    private GameManager _manager;

    public static UIMenuController Instance;

    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
        Instance = this;
    }

    public void StartGame(bool girl)
    {
        _manager.StartGame(girl);
    }
}
