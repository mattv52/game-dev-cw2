using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject ConfirmPanel;
    public GameObject interactive; 
    public int scene;

    void OnTriggerEnter2D(Collider2D collision)
    {
        interactive.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactive.SetActive(false);

    }
    public void confirm()
    {
        ConfirmPanel.SetActive(true);
    }

    public void cancel()
    {
        ConfirmPanel.SetActive(false);
    }

    public void next()
    {
        SceneManager.LoadScene(scene);
    }

}