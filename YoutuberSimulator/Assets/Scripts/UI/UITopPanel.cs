using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITopPanel : UIObject
{
    private PlayerController _playerController { get { return PlayerController.Instance; } }
    private ActionsController _actionsController { get { return ActionsController.Instance; } }

    public TextMeshProUGUI SubsText;
    public TextMeshProUGUI CurrentActionText;

    public override void RefreshObject()
    {
        SubsText.text = GameTranslate.GetTranslation("SUBCOUNT") + ": "  + _playerController.Subs.ToString();

        switch (_actionsController.CurrentAction.ToString())
        {
            case ("Streaming"):
                CurrentActionText.text = GameTranslate.GetTranslation("STREAMING");
                break;
            case ("Watching"):
                CurrentActionText.text = GameTranslate.GetTranslation("WATCHING");
                break;
            case ("Responding"):
                CurrentActionText.text = GameTranslate.GetTranslation("RESPONDING");
                break;
            case ("Walking"):
                CurrentActionText.text = GameTranslate.GetTranslation("WALKING");
                break;
            case ("Friends"):
                CurrentActionText.text = GameTranslate.GetTranslation("VISITING");
                break;
            default:
                break;
        }

        
    }
}
