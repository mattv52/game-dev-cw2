using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openSprite;
    public GameObject closedSprite;
    public string location;
    public bool open;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

    }

    void Update()
    {
        if (gm.job == location)
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
