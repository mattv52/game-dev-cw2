using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class NPC_Gang_Leader_3 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject speech_bubble;
    public TMP_Text speech_bubble_text;
    public SpriteRenderer background;
    public float paddx = 0f;
    public float paddy = 0f;
    public GameObject attack_button;
    public GameObject kill_button;
    public Tilemap walls;

    private Inventory player_inventory;
    public GameObject blood_splater;

    private string[] speeches = {"What you want", "Think youll get away with this", "Your not that useful are you", "Were leaving<br>joing us if you want"};
    private System.Random rnd = new System.Random();
    private int text = 0;

    // Start is called before the first frame update
    void Start()
    {
        player_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        speech_bubble.SetActive(false);

        if (GameState.kill_gang_leader)
        {
            sprite.color = new Color(1f, 0, 0, 1);
            Destroy(speech_bubble);
        }
        else if (GameState.attack_gang_leader)
        {
            sprite.color = new Color(0.5f, 0, 0, 1);
            text = 1;
        }
        else if (GameState.accept_gang_job)
        {
            if (GameState.gang_break_out)
            {
                text = 3;
                transform.position = new Vector3(33.07f, -12.9f, -1.0f);
                walls.SetTile(new Vector3Int(30, -15, 0), null);
                walls.SetTile(new Vector3Int(30, -16, 0), null);
                walls.SetTile(new Vector3Int(31, -15, 0), null);
                walls.SetTile(new Vector3Int(31, -16, 0), null);
            }
            else
            {
                text = 2;
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
        GameState.kill_gang_leader = true;
        Destroy(speech_bubble);
        sprite.color = new Color(1, 0, 0, 1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blood_splater, pos, Quaternion.identity);
    }

    public void Attack()
    {
        GameState.attack_gang_leader = true;
        text = 2;
        sprite.color = new Color(0.5f, 0, 0, 1);
        speech_bubble_text.SetText(speeches[text]);
        updateTextBubble();
        Destroy(attack_button);
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
