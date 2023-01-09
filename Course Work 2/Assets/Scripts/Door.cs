using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openSprite;
    public GameObject closedSprite;

    public void open()
    {
        openSprite.SetActive(true);
        closedSprite.SetActive(false);
        Time.timeScale = 1;
    }

}
