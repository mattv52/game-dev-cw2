using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openSprite;
    public GameObject closedSprite;
    public string location;
    public bool open;

    void Update()
    {
        if (GameState.job == location)
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
