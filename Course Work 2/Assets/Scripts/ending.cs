using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public TMP_Text endingText;
    
    private GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject inventory = GameObject.FindGameObjectWithTag("UI");

        player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        inventory.SetActive(false);

        gs = GameState.Instance;

        if (gs.caughtMurder)
        {
            endingText.SetText("You killed another inmate<br>the guard notices and sent you to solitary");
        }
        else if (gs.attackGuard)
        {
            endingText.SetText("You attacked a guard <br> and were sent to solitary");
        }
        else if (gs.attackWarden)
        {
            endingText.SetText("You attacked the warden <br> and were sent to solitary");
        }
        else if (gs.caughtWithKnife)
        {
            endingText.SetText("The Cook notice you stal one of his knives <br> you were sent to solitary");
        }
        else if (gs.escaped)
        {
            endingText.SetText("You escaped, and find out the gang was going to<br>kill you and use you as a distraction when attacking<br><br>but your investigation caused enough attention to work<br>they decided to leave you in your freedom");
        }
        else if (gs.killAttackerUnNoticed)
        {
            endingText.SetText("You killed the attacker<br>and it seemed no one else noticed");
        }
        else if (gs.killAttackerNoticed || gs.kill_gang_lackey)
        {
            endingText.SetText("You killed the attacker<br>but the guards noticed<br>and now youve got a life sentance");
        }
        else if (gs.rat)
        {
            endingText.SetText("The attacker has been delt with,<br>but now the rest of the prison is wary of you");
        }
        else 
        {
            endingText.SetText("You didnt deal with the killer<br>and were found dead the next day");
        }
    }

    public void reset()
    {
        gs.reset();
        // player.SetActive(false);
        // UI.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
