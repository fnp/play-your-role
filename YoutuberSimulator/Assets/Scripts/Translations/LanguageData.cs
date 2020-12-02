using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Objects/Language Data")]
public class LanguageData : ScriptableObject
{
        public Dictionary<string, string> Translations;
}
