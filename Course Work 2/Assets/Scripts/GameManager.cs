using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Add public variables here to record state i.e.
    // public int x; 

    // reference the variables anywhere as:
        // GameManager.Instance.x

    void Awake()
    {
        if (Instance != null)
            GameObject.Destroy(Instance);
        else
            Instance = this;

        DontDestroyOnLoad(this);
    }
}