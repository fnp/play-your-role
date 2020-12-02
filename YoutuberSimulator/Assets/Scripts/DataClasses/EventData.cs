using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Objects/Event Data")]
public class EventData : ScriptableObject
{
    public string Description;
    public string OptionOneDescription;
    public string OptionTwoDescription;

    public ModifierType OptionOneType1;
    public ModifierType OptionOneType2;
    public ModifierType OptionTwoType1;
    public ModifierType OptionTwoType2;

    public float OptionOneAmount1;
    public float OptionOneAmount2;
    public float OptionTwoAmount1;
    public float OptionTwoAmount2;
}

public enum ModifierType
{
    Subs,
    Stress,
    Passion,
    PositiveComments,
    NegativeComments,
    HatefullComments
}
