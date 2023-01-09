using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadMorning : MonoBehaviour
{
    public GameObject UI;
    public GameObject infoPanel;
    public GameObject storyPanel;
    public Sprite icon;


    void Start()
    {
        Time.timeScale = 0;
        UI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icon;
        UI.transform.GetChild(0).GetChild(0).localScale = new Vector3(1f, 0.75f, 1f);
        UI.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = "Morning";
    }

    public void readInfo()
    {
        UI.SetActive(true);
        infoPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void readStory()
    {
        storyPanel.SetActive(false);
        infoPanel.SetActive(true);
    }
}