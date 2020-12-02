using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFaceSwapper : UIObject
{
    private PlayerController _playerController { get { return PlayerController.Instance; } }

    public Image FaceTarget;

    public Sprite Crying;
    public Sprite Stressed;
    public Sprite Neutral;
    public Sprite Happy;
    public Sprite Excited;

    float currentState;

    public override void RefreshObject()
    {
        currentState = _playerController.Stress;

        SetFace();
    }

    void SetFace()
    {
        if(currentState <= 10)
        {
            FaceTarget.sprite = Excited;
        }
        else if(currentState <= 30)
        {
            FaceTarget.sprite = Happy;
        }
        else if (currentState <= 60)
        {
            FaceTarget.sprite = Neutral;
        }
        else if (currentState <= 80)
        {
            FaceTarget.sprite = Stressed;
        }
        else
        {
            FaceTarget.sprite = Crying;
        }
    }
}