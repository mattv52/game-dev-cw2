using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;

    private GameState gs;

    void Start(){
        gs = GameState.Instance;
    }

    public void pause()
    {
        GameState.Instance.job = "changed";
        Time.timeScale = 0;
        canvas.SetActive(true);
        
    }

    public void play()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
