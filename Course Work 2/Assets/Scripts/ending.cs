using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ending : MonoBehaviour
{
    public TMP_Text endingText;
    
    private GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Instance;

        if (gs.escaped)
        {
            endingText.SetText("You escaped, and find out the gang was going to kill you and use you as a distraction when attacking, but your investigation caused enough attention to work");
        }
        else if (gs.killAttackerUnNoticed)
        {
            endingText.SetText("You killed the attacker, and it seemed no one else noticed");
        }
        else if (gs.killAttackerNoticed || gs.kill_gang_lackey)
        {
            endingText.SetText("You killed the attacker, but the guards noticed, and now youve got a life sentance");
        }
        else if (gs.rat)
        {
            endingText.SetText("The attacker has been delt with, but now the rest of the prison is wary of you");
        }
        else 
        {
            endingText.SetText("You didnt deal with the killed");
        }
    }

}
