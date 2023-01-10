using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Warden_3 : MonoBehaviour
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
    public string item_wanted;
    public GameObject blood_splater;
    public AudioClip[] clips;

    private AudioSource sound;
    private GameState gs;

    private string[] speeches = {"Why are you in my office?","Leave me alone",
        "You know im the warden right?", "Do you have anything?", "This is good<br>You'll be fine.<br>I can take care of this"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;
        sound = GetComponent<AudioSource>();   
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);

        if (gs.kill_warden)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (gs.attack_warden)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
            Destroy(accept_button);

        }
        else if (gs.warden_Wants_More_Proof)
        {
            text = 3;
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
        sound.clip = clips[rnd.Next(4)];
        sound.Play();
        
        SceneLoader sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        gs.attackWarden = true;
        sl.LoadNignt();

        gs.kill_warden = true;
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
        gs.attackWarden = true;
        sl.LoadNignt();

        gs.attack_warden = true;
        sprite.color = new Color(0.5f, 0, 0, 1);
        text = 2;
        Destroy(accept_button);
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
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
                    
                    text = 4;
                    speech_bubble_text.SetText(speeches[text]);
                    updateTextBubble();
                    Destroy(accept_button);

                    gs.rat = true;
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
