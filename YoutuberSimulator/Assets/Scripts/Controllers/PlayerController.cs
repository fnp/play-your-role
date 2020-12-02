using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerManager _manager;

    public static PlayerController Instance;

    private void Awake()
    {
        _manager = FindObjectOfType<PlayerManager>();
        Instance = this;
    }

    public void RestartGame() => _manager.RestartGame();
    public string GameOver() => _manager.GameOver();
    public float Passion => _manager.Passion;
    public float Stress => _manager.Stress;
    public int Subs => _manager.Subs;
    public bool Girl => _manager.Girl;
}
