using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Informant : MonoBehaviour
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
    public Inventory player_inventory;
    public string item_wanted;
    public GameObject blood_splater;
    public AudioClip[] clips;

    private AudioSource sound;
    private GameState gs;
    private SceneLoader sl;

    private string[] speeches = {"Might be able to help you with that note for a cigie",
        "I saw that big guy in yard<br>hanging round your cell last night", "Oww, ok, ill tell you<br>Saw that big guy outside hanging<br>round your cell last night", "Why would you do this", "Rumour has it there was<br>a note left in your room?"};
    private System.Random rnd = new System.Random();
    private int text = 4;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        sound = GetComponent<AudioSource>();
        speech_bubble.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (speeches.Length > 0)
        {
            foreach (GameObject slot in player_inventory.slots)
            {
                if (slot.gameObject.transform.childCount > 0)
                {
                    GameObject item = slot.gameObject.transform.GetChild(0).gameObject;
                    if (item.tag == "Shive")
                    {
                        kill_button.SetActive(true);
                    } else if (item.tag == "Note")
                        if (gs.give_Cigaret_To_Informant == false)
                        {
                            text = 0;
                        }
                }
            }
            speech_bubble.SetActive(true);
            kill_button.SetActive(false);
            print(text);
            speech_bubble_text.SetText(speeches[text]);
            updateTextBubble();

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speech_bubble.SetActive(false);

    }

    public void Kill()
    {
        sound.clip = clips[rnd.Next(4)];
        sound.Play();

        gs.caughtMurder = true;
        gs.kill_informant = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
        sl.LoadNignt();
    }

    public void Attack()
    {
        sound.clip = clips[rnd.Next(4)];
        sound.Play();
        sprite.color = new Color(0.5f, 0, 0, 1);
        gs.attack_informant = true;
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
                    gs.give_Cigaret_To_Informant = true;
                    GameObject.Destroy(item.gameObject);

                    text = 1;
                    speech_bubble_text.SetText(speeches[text]);
                    updateTextBubble();
                    Destroy(accept_button);
                    return;
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
