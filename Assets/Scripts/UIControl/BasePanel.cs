using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    public static T Instance { get; private set; }

    protected void Awake()
    {
        Instance = this as T;
    }

    /// <summary>
    /// false = hide, true = show
    /// </summary>
    /// <param name="status"></param>
    public virtual void HideOrShow(bool status)
    {
        gameObject.SetActive(status);
    }
}