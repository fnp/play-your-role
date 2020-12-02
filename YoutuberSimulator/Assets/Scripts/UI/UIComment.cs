using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIComment : MonoBehaviour
{
    public TextMeshProUGUI CommentText;
    public Color[] CommentColor;
    public Image Background;

    public void SetComment(ChatMessage comment)
    {
        CommentText.text = comment.Content;
        gameObject.SetActive(true);

        switch (comment.Type)
        {
            case MessegeType.Hatefull:
                Background.color = CommentColor[3];
                break;
            case MessegeType.Negative:
                Background.color = CommentColor[2];
                break;
            case MessegeType.Neutral:
                Background.color = CommentColor[1];
                break;
            case MessegeType.Positive:
                Background.color = CommentColor[0];

                break;
        }
    }

    public void RestartComment()
    {
        gameObject.SetActive(false);
    }
}