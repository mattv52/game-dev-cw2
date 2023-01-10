using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameState gs;

    void Start()
    {
        gs = GameState.Instance;
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        print(scene);
        print(mode);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void reset()
    {
        gs.reset();
        Time.timeScale = 1;
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
    }

    // public void LoadMidday()
    // {
    //     SceneManager.LoadScene(2);
    // }

    // public void LoadAfternoon()
    // {
    //     SceneManager.LoadScene(3);
    // }

    public void LoadNignt()
    {
         SceneManager.LoadScene("Night");
    }
}
