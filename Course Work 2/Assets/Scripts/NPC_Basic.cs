using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NPC_Basic : MonoBehaviour
{
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;

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
            speech_bubble.SetActive(true);
            int text  = rnd.Next(0, speeches.Length);
            speech_bubble_text.SetText(speeches[text]);

            speech_bubble_text.ForceMeshUpdate();
            Vector2 text_size = speech_bubble_text.GetRenderedValues(false);
            Vector2 padding = new Vector2(paddx, paddy);
            background.size = text_size + padding;

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speech_bubble.SetActive(false);

    }

    public void Die()
    {
    	print("Dead");
    }
}
