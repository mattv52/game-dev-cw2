using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAfternoon : MonoBehaviour
{
    public GameObject jobPanel;
    private GameState gs;
        
    void Start()
    {
        gs = GameState.Instance;
    }


    public void job(string j)
    {
        gs.job = j;
        jobPanel.SetActive(false);
    }
}
