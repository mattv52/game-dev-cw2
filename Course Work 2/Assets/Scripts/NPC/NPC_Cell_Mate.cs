using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Cell_Mate : MonoBehaviour
{
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;
    public GameObject shiv_item;
    public GameObject accept_button;
    public GameObject attack_button;
    public Inventory player_inventory;
    public string item_wanted;

    private string[] speeches = {"Hey, ill give you my shank<br>if you give me your breakfast",
        "Thanks man", "Piss off", "Why would you do this"};
    private System.Random rnd = new System.Random();
    private int text = 0;

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
            print(text);
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speech_bubble.SetActive(false);

    }

    public void DieC()
    {
        if (text == 1)
        {
            text = 3;
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();
            Destroy(attack_button);
        }
        else
        {

            text = 2;
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();
            Destroy(accept_button);
            Destroy(attack_button);

            Vector2 npcPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(shiv_item, npcPos, Quaternion.identity);
        }
    }

    public void Agree() 
    {
        foreach (GameObject slot in player_inventory.slots)
        {
            if (slot.gameObject.transform.childCount > 0)
            {
                GameObject item = slot.gameObject.transform.GetChild(0).gameObject;
                if (item.tag == item_wanted)
                {
                    GameObject.Destroy(item.gameObject);

                    text = 1;
                    speech_bubble_text.SetText(speeches[text]);
                    updateTextBubble();
                    Destroy(accept_button);

                    Vector2 npcPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
                    Instantiate(shiv_item, npcPos, Quaternion.identity);
                }
            }
        }
    }

    private void updateTextBubble()
    {
        speech_bubble_text.ForceMeshUpdate();
        Vector2 text_size = speech_bubble_text.GetRenderedValues(false);
        Vector2 padding = new Vector2(paddx, paddy);
        background.size = text_size + padding;
    }
}
