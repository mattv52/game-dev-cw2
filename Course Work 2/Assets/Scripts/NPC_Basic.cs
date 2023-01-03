using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NPC_Basic : MonoBehaviour
{
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;

    public string[] speeches;
	private System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        speech_bubble.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (speeches.Length > 0) 
        {
            int text  = rnd.Next(0, speeches.Length);
            speech_bubble_text.text = speeches[text];
            speech_bubble.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speech_bubble.SetActive(false);

    }

}
