using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;

    public void pause()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
    }

    public void play()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
