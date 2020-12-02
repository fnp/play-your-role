using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateStringCont : MonoBehaviour
{
    [SerializeField]
    string key;

    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = GameTranslate.GetTranslation(key);
    }

    void Update()
    {
        text.text = GameTranslate.GetTranslation(key);
    }
}
