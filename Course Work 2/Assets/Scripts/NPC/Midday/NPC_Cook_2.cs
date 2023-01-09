using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Cook_2 : MonoBehaviour
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
    private SceneLoader sl;

    private string[] speeches = {"Just sit there and learn from me<br>and dont take my knifes.<br>Im watching you", "Why are you here?", "Needed this break", "Oww<br>shouldnt have let you in this kitchen",
    "Ow<br>Thought you were cool"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);
        if (gs.kill_cook)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_cook)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
        }
        else if (gs.give_Cigaret_To_Cook)
        {
            text = 2;
            transform.position = new Vector3(33f, -10.15f, -1.0f);
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
        gs.kill_cook = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
    }

    public void Attack()
    {
        gs.attack_cook = true;
        if (gs.give_Cigaret_To_Cook)
        {
            text = 4;
        }
        else
        {
            text = 3;
        }
        sprite.color = new Color(0.5f, 0, 0, 1);
        updateTextBubble();

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
