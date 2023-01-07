using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        // Big if tree to determine how to end the game.
        // These will need to be ordered in order of priority in the case that multiple are completed
        if (gm.eaten == false)
        {
            // Die of hunger
        }
        else if (true)
        {
            // Something else
        }
        else
        {
            // Default (Die by gang I think)
        }
    }
}
