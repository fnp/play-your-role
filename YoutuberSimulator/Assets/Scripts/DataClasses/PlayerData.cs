using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Objects/Player Data")]
public class PlayerData : ScriptableObject
{
    public bool Girl;
    public float Passion;
    public float Stress;
    public int Subs;
    public int[] SubsTresholds;
    public ActionType CurrentAction;
}
