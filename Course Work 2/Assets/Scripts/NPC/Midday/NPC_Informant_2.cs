using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Informant_2 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;
    public GameObject accept_button;
    public GameObject attack_button;
    public GameObject kill_button;

    private Inventory player_inventory;
    public GameObject disc_item;
    public GameObject blood_splater;

    private string[] speeches = {"Hi", "Watch it", "You need proof<br>if you know what<br>those two are planning i can help", "heres a video of them planthing the note"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);

        if (GameState.kill_informant)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (GameState.attack_informant)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
            Destroy(accept_button);
        }
        else if (GameState.give_Cigaret_To_Informant && GameState.warden_Wants_More_Proof)
        {
            text = 2;
        }
        else
        {
            Destroy(accept_button);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (speeches.Length > 0)
        {
            speech_bubble.SetActive(true);
            kill_button.SetActive(false);
            accept_button.SetActive(false);
            print(text);
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();

            if (GameState.gang_break_out)
            {
                accept_button.SetActive(true);
            }

            foreach (GameObject slot in player_inventory.slots)
            {
                if (slot.gameObject.transform.childCount > 0)
                {
                    GameObject item = slot.gameObject.transform.GetChild(0).gameObject;
                    if (item.tag == "Shive")
                    {
                        kill_button.SetActive(true);
                    }
                }
            }
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speech_bubble.SetActive(false);

    }

    public void Kill()
    {
        GameState.kill_informant = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        GameState.attack_informant = true;
        text = 1;
        sprite.color = new Color(0.5f, 0, 0, 1);
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
        Destroy(attack_button);
    }

    public void Agree() 
    {
        if (GameState.gang_break_out)
        {
            text = 3;
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();
            Destroy(accept_button);

            Vector2 npcPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(disc_item, npcPos, Quaternion.identity);
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
