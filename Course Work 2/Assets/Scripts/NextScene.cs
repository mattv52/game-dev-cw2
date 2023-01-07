using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextScene : MonoBehaviour
{
    public GameObject ConfirmPanel;
    public GameObject interactive; 
    public string next_scene;

    private bool eating;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        interactive.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactive.SetActive(false);

    }
    public void eat(bool eaten)
    {
        string text = $"will progress time to {next_scene}.<br>Are you sure you want to continue?";
        // print(ConfirmPanel.transform.GetChild(0));
        if (eaten)
        {
            eating = true;
            text = "Eating this now "+text;
        }
        else
        {
            eating = false;
            text = "Saving this for later "+text;
        }
            
        ConfirmPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
        ConfirmPanel.SetActive(true);
    }

    public void cancel()
    {
        ConfirmPanel.SetActive(false);
    }

    public void next()
    {
        if (gm.eaten == false)
            gm.eaten = eating;
        SceneManager.LoadScene(next_scene);
    }

}