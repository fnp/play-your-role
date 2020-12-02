using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEndGamePanels : MonoBehaviour
{
    private PlayerController _playerController { get { return PlayerController.Instance; } }

    public GameObject EndGamePanel;
    public TextMeshProUGUI EndGameDescription;

    public void SetPanel(string endGameText)
    {
        EndGamePanel.SetActive(true);
        EndGameDescription.text = endGameText;
    }

    public void RestartGame()
    {
        EndGamePanel.SetActive(false);
        _playerController.RestartGame();
    }
}
