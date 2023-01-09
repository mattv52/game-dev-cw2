using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour
{
    public string next_scene;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameState.escaped = true;
        SceneManager.LoadScene(next_scene);

    }
}
