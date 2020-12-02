using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateString : MonoBehaviour
{
    [SerializeField]
    string key;

    void Start()
    {
        GetComponent<TMP_Text>().text = GameTranslate.GetTranslation(key);
    }
}
