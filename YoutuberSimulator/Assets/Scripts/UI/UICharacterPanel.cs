using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterPanel : UIObject
{
    private PlayerController _playerController { get { return PlayerController.Instance; } }

    public Slider PassionSlider;
    public Slider StressSilder;

    public UIEndGamePanels EndGamePanel;

    public override void RefreshObject()
    {
        PassionSlider.value = _playerController.Passion / 100f;
        StressSilder.value = _playerController.Stress / 100f;

        if(_playerController.Passion <= 0 || _playerController.Stress >= 100)
        {
            ShowEndGamePanel();
        }
    }

    void ShowEndGamePanel()
    {
        var endGameText = _playerController.GameOver();
        EndGamePanel.SetPanel(endGameText);
    }
}
