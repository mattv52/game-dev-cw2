using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Warden_2 : MonoBehaviour
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

    private string[] speeches = {"What do you want?<br>And shouldn't I have a door",
        "Your going to need more<br>proof then a note", "*kill player*", "*kill player*"};
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
        gs.attackWarden = true;
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
        
        sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.attackWarden = true;
        sl.LoadNignt();
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
                    GameObject.Destroy(item.gameObject);

                    text = 1;
                    speech_bubble_text.SetText(speeches[text]);
                    updateTextBubble();
                    Destroy(accept_button);
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
