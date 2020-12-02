using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIChatPanel : UIObject
{
    private ChatController _chatController { get { return ChatController.Instance; } }

    public UIComment[] CommentsBoxes;
    public UIEmoteSpawner EmoteSpawner;

    public TextMeshProUGUI HatefullChance;

    ChatMessage[] holdMesseges = new ChatMessage[3];
    int heldIndex = 0;

    private void Start()
    {
        _chatController.CallGameRestarted += GameRestarted;
    }

    public override void RefreshObject()
    {
        if (_chatController.IsMessageToBeDisplayed)
        {
            holdMesseges[0] = holdMesseges[1];
            holdMesseges[1] = holdMesseges[2];
            holdMesseges[2] = _chatController.DisplayMessage;
            
            DisplayMessage();
            EmoteSpawner.SpawnEmote(holdMesseges[2].Type);
        }

        HatefullChance.text = GameTranslate.GetTranslation("HATEFULLCHANCE") + ": " + _chatController.HatefullChance.ToString("0.0") + "%";
    }

    void GameRestarted()
    {
        holdMesseges = new ChatMessage[3];

        for (int i = 0; i < holdMesseges.Length; i++)
        {
            CommentsBoxes[i].RestartComment();
        }
    }

    void DisplayMessage()
    {
        for (int i = 0; i < holdMesseges.Length; i++)
        {
            if(holdMesseges[i] != null)
            {
                CommentsBoxes[i].SetComment(holdMesseges[i]);
            }
        }
    }
    
}
