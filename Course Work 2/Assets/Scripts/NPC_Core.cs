using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Core : NPC_Basic
{
    public GameObject panel;
    public GameObject grid;
    public GameObject template;
    public string[] replies;

    void Start() 
    {
        panel.SetActive(false);
    }

    public void Talk()
    {
        panel.SetActive(true);
        
        foreach (string reply in replies)
        {
            GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
            temp.transform.SetParent(grid.transform);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = reply;
        }

    }

    // Give Item
}
