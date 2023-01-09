using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;

    private void Awake()
    {
        UI.SetActive(false);
        player.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void reset()
    {
        GameState.reset();
        player.SetActive(false);
        UI.SetActive(false);
        SceneManager.LoadScene(0);
    }

    // public void LoadMenu()
    // {
    //     SceneManager.LoadScene(0);
    // }

    // public void LoadIntro()
    // {
    //     SceneManager.LoadScene(1);
    // }

    public void LoadMorning()
    {
        SceneManager.LoadScene("Morning");
        player.SetActive(true);
        UI.SetActive(true);
    }

    // public void LoadMidday()
    // {
    //     SceneManager.LoadScene(2);
    // }

    // public void LoadAfternoon()
    // {
    //     SceneManager.LoadScene(3);
    // }

    // public void LoadNignt()
    // {
    //     SceneManager.LoadScene(4);
    // }
}
