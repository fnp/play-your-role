using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIObject : MonoBehaviour
{
    public abstract void RefreshObject();

    private void OnEnable()
    {
        UIRefreshManager.Refresh += RefreshObject;
    }

    private void OnDisable()
    {
        UIRefreshManager.Refresh -= RefreshObject;
    }
}
