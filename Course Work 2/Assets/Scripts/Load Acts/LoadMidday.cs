using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadMidday : MonoBehaviour
{
    public Sprite icon;
    public GameObject jobPanel;
      
    void Start()
    {
        GameObject UI = GameObject.FindGameObjectWithTag("UI");
        UI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icon;
        UI.transform.GetChild(0).GetChild(0).localScale = new Vector3(1f, 0.85f, 1f);
        UI.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = "Midday";
        Time.timeScale = 0;
    }


    public void job()
    {
        jobPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
