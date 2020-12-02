using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEmoteSpawner : MonoBehaviour
{
    public Sprite[] PositiveEmotes;
    public Sprite[] NeutralEmotes;
    public Sprite[] NegativeEmotes;
    public Sprite[] HateFullEmotes;

    public UIEmote emotePrefab;
    List<UIEmote> emotes;

    void Awake()
    {
        emotes = new List<UIEmote>();

        for (int i = 0; i < 50; i++)
        {
            UIEmote obj = Instantiate(emotePrefab);
            obj.gameObject.SetActive(false);
            obj.GetComponent<Transform>().SetParent(gameObject.transform);
            emotes.Add(obj);
        }
    }

    Vector3 SpawnPostion()
    {
        Vector3 position = new Vector3();

        position = transform.position;
        position.x = position.x + Random.Range(-50, 50);
        position.y = position.y + Random.Range(-5, 5);

        return position;

    }

    Sprite GetIcon(MessegeType type)
    {
        switch (type)
        {
            case MessegeType.Negative:
                return NegativeEmotes[Random.Range(0, NegativeEmotes.Length)];
            case MessegeType.Neutral:
                return NeutralEmotes[Random.Range(0, NeutralEmotes.Length)];
            case MessegeType.Positive:
                return PositiveEmotes[Random.Range(0, PositiveEmotes.Length)];
            case MessegeType.Hatefull:
                return HateFullEmotes[Random.Range(0, HateFullEmotes.Length)];
            default:
                return null;
        }
    }

    public void SpawnEmote(MessegeType type)
    {
        for (int i = 0; i < emotes.Count; i++)
        {
            if (!emotes[i].isActiveAndEnabled)
            {
                emotes[i].transform.position = SpawnPostion();
                emotes[i].SetIcon(GetIcon(type));
                break;
            }
        }
    }
}