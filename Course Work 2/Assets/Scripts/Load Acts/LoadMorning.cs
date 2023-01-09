using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMorning : MonoBehaviour
{
    public GameObject UI;
    public GameObject infoPanel;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void readInfo()
    {
        UI.SetActive(true);
        infoPanel.SetActive(false);
        Time.timeScale = 1;
    }
}