using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Cell_Mate_2 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;
    public GameObject guard_button;
    public GameObject attack_button;
    public GameObject kill_button;

    private Inventory player_inventory;
    public GameObject blood_splater;
    public AudioClip[] clips;

    private AudioSource sound;
    private GameState gs;
    private SceneLoader sl;

    private string[] speeches = {"Hi", "Hey I could distact<br>the guard if that helps you", "Leave me alone", "Why", "Ill keep him busy<br>this afternoon"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        sound = GetComponent<AudioSource>();
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        speech_bubble.SetActive(false);
        if (gs.kill_cellmate)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_cellmate)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 2;
            Destroy(guard_button);
        }
        else if (gs.cell_Mate_Trade_Shive)
        {
            text = 1;
        }
        else
        {
            Destroy(guard_button);
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
        sound.clip = clips[rnd.Next(4)];
        sound.Play();
        
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.caughtMurder = true;
        sl.LoadNignt();

        gs.kill_cellmate = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        sound.clip = clips[rnd.Next(4)];
        sound.Play();
        
        gs.attack_cellmate = true;
        sprite.color = new Color(0.5f, 0, 0, 1);
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
            Destroy(attack_button);
        }
    }

    public void Agree() 
    {
        text = 4;
        gs.cell_Mate_Distract_Guard = true;
        updateTextBubble();
        Destroy(guard_button);
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
