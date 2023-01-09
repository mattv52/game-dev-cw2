using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Gang_Lackey_3 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;
    public GameObject attack_button;
    public GameObject kill_button;
    private Inventory player_inventory;
    public GameObject blood_splater;

    private GameState gs;
        
    private string[] speeches = {"What you looking at","I'll get you for this", "Lets get going"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        if (gs.kill_gang_lackey) 
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_gang_lackey)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
        }else if (gs.accept_gang_job)
        {
            if (gs.gang_break_out)
            {
                text = 2;
                transform.position = new Vector3(30.07f, -10.9f, -1.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (speeches.Length > 0)
        {
            speech_bubble.SetActive(true);
            kill_button.SetActive(false);
            print(text);
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();

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
        if (gs.give_Cigaret_To_Guard == false)
        {
            SceneLoader sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
            gs.caughtMurder = true;
            sl.LoadNignt();
        }
        if (gs.give_Cigaret_To_Guard || gs.cell_Mate_Distract_Guard)
        {
            gs.killAttackerUnNoticed = true;
        }
        else
        {
            gs.killAttackerNoticed = true;
        }
        gs.kill_gang_lackey = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        gs.attack_gang_lackey = true;
        text = 1;
        sprite.color = new Color(0.5f, 0, 0, 1);
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
        Destroy(attack_button);
    }

    private void updateTextBubble()
    {
        speech_bubble_text.ForceMeshUpdate();
        Vector2 text_size = speech_bubble_text.GetRenderedValues(false);
        Vector2 padding = new Vector2(paddx, paddy);
        background.size = text_size + padding;
    }
}
