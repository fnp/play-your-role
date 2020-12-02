using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIRefreshManager : MonoBehaviour
{
    public float tickTime;

    float currentTimer;

    public static UnityAction Refresh;

    void Update()
    {
        currentTimer += Time.deltaTime;
        CheckTick();
    }

    void CheckTick()
    {
        if (currentTimer > tickTime)
        {
            currentTimer = 0;
            Refresh?.Invoke();
        }
    }
}
