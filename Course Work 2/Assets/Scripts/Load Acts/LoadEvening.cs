using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadEvening : MonoBehaviour
{
    public Sprite icon;
        
    void Start()
    {
        GameObject UI = GameObject.FindGameObjectWithTag("UI");
        UI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icon;
        UI.transform.GetChild(0).GetChild(0).localScale = new Vector3(1f, 0.75f, 1f);
        UI.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = "Evening";
    }
}
