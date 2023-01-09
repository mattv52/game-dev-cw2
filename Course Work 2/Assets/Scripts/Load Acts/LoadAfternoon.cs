using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAfternoon : MonoBehaviour
{
    public GameObject jobPanel;

    public void job(string j)
    {
        GameState.job = j;
        jobPanel.SetActive(false);
    }
}
