using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAfternoon : MonoBehaviour
{
    public GameObject jobPanel;

    private GameManager gm;

    void Awake()
    {
        gm = GameManager.Instance;
    }

    public void job(string j)
    {
        gm.job = j;
        jobPanel.SetActive(false);
    }
}
