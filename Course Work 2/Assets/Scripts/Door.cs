using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openSprite;
    public GameObject closedSprite;
    public string location;
    public bool open;

    private GameState gs;

    void Start() {
        gs = GameState.Instance;
    }

    void Update()
    {
        if (gs.job == location)
        {
            open = true;
        }

        if (open)
        {
            openSprite.SetActive(true);
            closedSprite.SetActive(false);
        }
        else
        {
            openSprite.SetActive(false);
            closedSprite.SetActive(true);
        }
    }

}
