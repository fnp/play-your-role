using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public void SetLanguage(int index)
    {
        switch (index)
        {
            case 0:
                PlayerPrefs.SetInt("_language_index", index);
                PlayerPrefs.SetString("_language", "en");
                GameTranslate.Instance.LoadLanguage();
                break;
            case 1:
                PlayerPrefs.SetInt("_language_index", index);
                PlayerPrefs.SetString("_language", "pl");
                GameTranslate.Instance.LoadLanguage();
                break;
            default:
                PlayerPrefs.SetInt("_language_index", index);
                PlayerPrefs.SetString("_language", "en");
                GameTranslate.Instance.LoadLanguage();
                break;
        }
    }
}
