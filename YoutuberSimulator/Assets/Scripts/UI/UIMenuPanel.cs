using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuPanel : MonoBehaviour
{
    private UIMenuController _menuController { get { return UIMenuController.Instance; } }

    public void StartGame(bool girl)
    {
        _menuController.StartGame(girl);
    }
}
