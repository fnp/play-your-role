using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : UIObject
{
    private ActionsController _actionsController { get { return ActionsController.Instance; } }
    private PlayerController _playerController { get { return PlayerController.Instance; } }

    public Image Character;

    public UIFaceSwapper GirlFace;
    public UIFaceSwapper BoyFace;

    public Sprite GirlStreaming;
    public Sprite BoyStreaming;
    public Sprite GirlWatching;
    public Sprite BoyWatching;
    public Sprite GirlResponding;
    public Sprite BoyResponding;

    public GameObject CharacterFace;
    public Sprite Out;
    Sprite Streaming;
    Sprite Watching;
    Sprite Responding;

    bool GenderSet;

    public override void RefreshObject()
    {
        SetGender();

        switch (_actionsController.CurrentAction)
        {
            case ActionType.Streaming:
                Character.sprite = Streaming;
                CharacterFace.SetActive(true);
                break;
            case ActionType.Watching:
                Character.sprite = Watching;
                CharacterFace.SetActive(false);
                break;
            case ActionType.Responding:
                Character.sprite = Responding;
                CharacterFace.SetActive(true);
                break;
            case ActionType.Walking:
                Character.sprite = Out;
                CharacterFace.SetActive(false);
                break;
            case ActionType.Friends:
                Character.sprite = Out;
                CharacterFace.SetActive(false);
                break;
        }
    }

    void SetGender()
    {
        if (!GenderSet)
        {
            if (_playerController.Girl)
            {
                Streaming = GirlStreaming;
                Responding = GirlResponding;
                Watching = GirlWatching;
                BoyFace.gameObject.SetActive(false);
            }
            else
            {
                Streaming = BoyStreaming;
                Responding = BoyResponding;
                Watching = BoyWatching;
                GirlFace.gameObject.SetActive(false);
            }

            Character.sprite = Streaming;
            GenderSet = true;
        }
    }
}
