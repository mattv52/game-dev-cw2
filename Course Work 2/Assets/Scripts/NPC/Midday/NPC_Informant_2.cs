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

    private GameState gs;
    private SceneLoader sl;

    private Inventory player_inventory;
    public GameObject disc_item;
    public GameObject blood_splater;

    private string[] speeches = {"Hi", "Watch it", "You need proof<br>If you know what<br>those two are planning I can help", "Heres a video of them planting the note", "Fine here, leave me alone"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);

        if (gs.kill_informant)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_informant)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
            Destroy(accept_button);
        }
        else if (gs.give_Cigaret_To_Informant && gs.warden_Wants_More_Proof)
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

            if (gs.gang_break_out)
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
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.caughtMurder = true;
        sl.LoadNignt();
        gs.kill_informant = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        if (gs.give_Cigaret_To_Informant && gs.warden_Wants_More_Proof)
        {
            gs.getDisc = true;
            Vector2 npcPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
            Instantiate(disc_item, npcPos, Quaternion.identity);
            gs.attack_informant = true;
            text = 4;
            sprite.color = new Color(0.5f, 0, 0, 1);
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();
            Destroy(attack_button);
            Destroy(accept_button);
        }
        else
        {
            gs.attack_informant = true;
            text = 1;
            sprite.color = new Color(0.5f, 0, 0, 1);
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();
            Destroy(attack_button);
        }

    }

    public void Agree() 
    {
        if (gs.gang_break_out)
        {
            text = 3;
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();
            Destroy(accept_button);

            gs.getDisc = true;
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
