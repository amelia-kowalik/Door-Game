using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public static event Action OnKeyAdded;
    
    private bool _hasKey = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKey()
    {
        _hasKey = true;
        OnKeyAdded?.Invoke();
    }

    public bool HasKey()
    {
        return _hasKey;
    }
}
