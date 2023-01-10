using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Guard_3 : MonoBehaviour
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
    public string item_wanted;
    public GameObject blood_splater;
    public AudioClip[] clips;

    private AudioSource sound;
    private GameState gs;
        
    private System.Random rnd = new System.Random();
    private string[] speeches = {"Move along", "Try me", "Thanks for the smoke", "Theres nothing here<br>quit wasting my time"};
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sound = GetComponent<AudioSource>();
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);

        if (gs.kill_guard)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_guard)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
            Destroy(attack_button);

        }
        else if (gs.cell_Mate_Distract_Guard)
        {
            text = 3;
            transform.position = new Vector3(48f, -13.3f, -1.0f);
        }
        else if (gs.give_Cigaret_To_Guard)
        {
            text = 2;
            transform.position = new Vector3(48f, -13.3f, -1.0f);
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
        
        SceneLoader sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.attackGuard = true;
        sl.LoadNignt();

        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        sound.clip = clips[rnd.Next(4)];
        sound.Play();
        
        SceneLoader sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.attackGuard = true;
        sl.LoadNignt();

        gs.attack_guard = true;
        text = 2;
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
