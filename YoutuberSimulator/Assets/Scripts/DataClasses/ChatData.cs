using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Objects/Messeges Data")]
public class ChatData : ScriptableObject
{
    public ChatMessage MessageToDisplay;
    public int GameTicks;
    public int[] TickTresholds;
    public string[] NegativeTexts;
    public string[] NeutralTexts;
    public string[] PositiveTexts;
    public string[] GirlHatefullTexts;
    public string[] BoyHatefullTexts;

    public int NeutralChance;
    public int PositiveChance;
    public int NegativeChance;

    public float HatefullChance;
}
