using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public TMP_Text endingText;
    public AudioSource sound;
    public AudioClip BadEnding;
    public AudioClip GoodEnding;
    public AudioClip Escape;

    private GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject inventory = GameObject.FindGameObjectWithTag("UI");

        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        inventory.SetActive(false);

        gs = GameState.Instance;

        if (gs.caughtMurder)
        {
            sound.clip = BadEnding;
            endingText.SetText("You killed another inmate<br>the guard notices and sent you to solitary");
        }
        else if (gs.attackGuard)
        {
            sound.clip = BadEnding;
            endingText.SetText("You attacked a guard <br> and were sent to solitary");
        }
        else if (gs.attackWarden)
        {
            sound.clip = BadEnding;
            endingText.SetText("You attacked the warden <br> and were sent to solitary");
        }
        else if (gs.caughtWithKnife)
        {
            sound.clip = BadEnding;
            endingText.SetText("The Cook notice you stal one of his knives <br> you were sent to solitary");
        }
        else if (gs.escaped)
        {
            sound.clip = Escape;
            endingText.SetText("You escaped, and find out the gang was going to<br>kill you and use you as a distraction when attacking<br><br>but your investigation caused enough attention to work<br>they decided to leave you in your freedom");
        }
        else if (gs.killAttackerUnNoticed)
        {
            sound.clip = GoodEnding;
            endingText.SetText("You killed the attacker<br>and it seemed no one else noticed");
        }
        else if (gs.killAttackerNoticed || gs.kill_gang_lackey)
        {
            sound.clip = BadEnding;
            endingText.SetText("You killed the attacker<br>but the guards noticed<br>and now youve got a life sentance");
        }
        else if (gs.rat)
        {
            sound.clip = GoodEnding;
            endingText.SetText("The attacker has been delt with,<br>but now the rest of the prison is wary of you");
        }
        else 
        {
            sound.clip = BadEnding;
            endingText.SetText("You didnt deal with the killer<br>and were found dead the next day");
        }
        sound.Play();
    }

    public void reset()
    {
        gs.reset();
        // player.SetActive(false);
        // UI.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
