using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextManager : MonoBehaviour
{

    //public TextMeshPro textBox;
    //public TextMeshPro button;
    public SceneLoader sceneLoader;

    private int state = 0;

// String[] textBoxText = ["You start to wake up in your prison cell",
//    "Theres something crumbly under in your bed",
//   "Its a note",
//    '"Your going to be killed the next night"'];

// String buttonText = ["...", "...", "Read note", "Get up"];

    public void nextText()
    {
        if (state == 3) {
            sceneLoader.LoadMorning();
        }

        state++;
        //textBox.text = textBoxText[state];
        //button.text = buttonText[state];

    }

}
