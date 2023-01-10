using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Gang_Leader : MonoBehaviour
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
    public Inventory player_inventory;
    public GameObject blood_splater;
    public AudioClip[] clips;

    private AudioSource sound;
    private GameState gs;
    private SceneLoader sl;

    private string[] speeches = {"You want me to protect you?<br>ok<br>But I need something from you", "Think you'll get away with this", "Get me them pliers from the<br>laundry room<br>then we can talk"};
    private System.Random rnd = new System.Random();
    private int text = 0;

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

        gs.caughtMurder = true;
        gs.kill_gang_leader = true;
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

        gs.attack_gang_leader = true;
        text = 1;
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
        Destroy(attack_button);
        Destroy(accept_button);
    }

    public void Agree()
    {
        gs.accept_gang_job = true;
        text = 2;
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
        Destroy(accept_button);
    }

    private void updateTextBubble()
    {
        speech_bubble_text.ForceMeshUpdate();
        Vector2 text_size = speech_bubble_text.GetRenderedValues(false);
        Vector2 padding = new Vector2(paddx, paddy);
        background.size = text_size + padding;
    }
}
