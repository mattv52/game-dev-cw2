using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Gang_Leader_2 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;
    public GameObject attack_button;
    public GameObject kill_button;
    public GameObject accept_button;

    public string item_wanted;

    private Inventory player_inventory;
    public GameObject blood_splater;

    private GameState gs;
    private SceneLoader sl;

    private string[] speeches = {"What you want","You got the stuff", "Think youll get away with this", "Nice<br>now we have this we can break out thorugh the fence<br>be here later on"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);

        if (gs.kill_gang_leader)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_gang_leader)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 2;
            Destroy(accept_button);
        }
        else if (gs.accept_gang_job)
        {
            text = 1;
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
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.caughtMurder = true;
        sl.LoadNignt();
        gs.kill_gang_leader = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        gs.attack_gang_leader = true;
        text = 2;
        sprite.color = new Color(0.5f, 0, 0, 1);
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
        Destroy(attack_button);
        Destroy(accept_button);
    }

    public void Accept()
    {
        gs.gang_break_out = true;
        foreach (GameObject slot in player_inventory.slots)
        {
            if (slot.gameObject.transform.childCount > 0)
            {
                GameObject item = slot.gameObject.transform.GetChild(0).gameObject;
                if (item.tag == item_wanted)
                {
                    GameObject.Destroy(item.gameObject);

                    text = 3;
                    updateTextBubble();
                    Destroy(accept_button);
                }
            }
        }
    }

    private void updateTextBubble()
    {
        speech_bubble_text.SetText(speeches[text]);
        speech_bubble_text.ForceMeshUpdate();
        Vector2 text_size = speech_bubble_text.GetRenderedValues(false);
        Vector2 padding = new Vector2(paddx, paddy);
        background.size = text_size + padding;
    }
}
