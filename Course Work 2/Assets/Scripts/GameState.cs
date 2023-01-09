using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool cell_Mate_Trade_Shive = false;
    public bool warden_Wants_More_Proof = false;
    public bool give_Cigaret_To_Cook = false;
    public bool give_Cigaret_To_Informant = false;
    public bool give_Cigaret_To_Guard = false;
    public bool accept_gang_job = false;

    public bool gang_break_out = false;

    public bool cell_Mate_Distract_Guard = false;
    public bool getDisc = false;

    public string job = "1";

    //endings
    public bool rat = false;
    public bool killAttackerUnNoticed = false;
    public bool killAttackerNoticed = false;
    public bool escaped = false;
    //
    public bool attack_cellmate = false;
    public bool kill_cellmate = false;
    //
    public bool attack_cook = false;
    public bool kill_cook = false;
    //
    public bool attack_informant = false;
    public bool kill_informant = false;
    
    public bool attack_guard = false;
    public bool kill_guard = false;
    //
    public bool attack_warden = false;
    public bool kill_warden = false;
    //
    public bool attack_gang_leader = false;
    public bool kill_gang_leader = false;
    //
    public bool attack_gang_lackey = false;
    public bool kill_gang_lackey = false;

    

    public void reset()
    {
        cell_Mate_Trade_Shive = false;
        warden_Wants_More_Proof = false;
        give_Cigaret_To_Cook = false;
        give_Cigaret_To_Informant = false;
        give_Cigaret_To_Guard = false;
        accept_gang_job = false;

        gang_break_out = false;

        cell_Mate_Distract_Guard = false;
        getDisc = false;

        job = "";

        //endings
        rat = false;
        killAttackerUnNoticed = false;
        killAttackerNoticed = false;
        escaped = false;
        //
        attack_cellmate = false;
        kill_cellmate = false;
        //
        attack_cook = false;
        kill_cook = false;
        //
        attack_informant = false;
        kill_informant = false;
        
        attack_guard = false;
        kill_guard = false;
        //
        attack_warden = false;
        kill_warden = false;
        //
        attack_gang_leader = false;
        kill_gang_leader = false;
        //
        attack_gang_lackey = false;
        kill_gang_lackey = false;
    }

    void Awake()
    {
        job = "test";
    }

    void Update()
    {
        print(job);
    }
}
