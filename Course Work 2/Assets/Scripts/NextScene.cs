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
    public AudioSource sound;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        interactive.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactive.SetActive(false);

    }
    public void eat()
    {
        string text = $"Eating this now will progress time to {next_scene}.<br>Are you sure you want to continue?";
        print("EAT");
        Time.timeScale = 0;
        ConfirmPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
        ConfirmPanel.SetActive(true);
    }

    public void cancel()
    {
        ConfirmPanel.SetActive(false);
    }

    public void next()
    {
        sound.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(next_scene);
    }

}