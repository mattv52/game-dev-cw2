using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMidday : MonoBehaviour
{
    public GameObject jobPanel;
    private GameState gs;
        
    void Start()
    {
        gs = GameState.Instance;
        Time.timeScale = 0;
    }


    public void job(string j)
    {
        gs.job = j;
        jobPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
