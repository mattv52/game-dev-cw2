using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour
{
    public string next_scene;

    private GameState gs;

    void Start() 
    {
        gs = GameState.Instance;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gs.escaped = true;
        SceneManager.LoadScene(next_scene);

    }
}
