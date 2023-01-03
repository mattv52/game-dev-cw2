using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMorning()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMidday()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadAfternoon()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadNignt()
    {
        SceneManager.LoadScene(4);
    }
}
