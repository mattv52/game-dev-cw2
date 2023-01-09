using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool cell_Mate_Trade_Shive = false;
    public static bool warden_Wants_More_Proof = false;
    public static bool give_Cigaret_To_Cook = false;
    public static bool give_Cigaret_To_Informant = false;
    public static bool give_Cigaret_To_Guard = false;
    public static bool accept_gang_job = false;

    public static bool gang_break_out = false;

    public static bool cell_Mate_Distract_Guard = false;
    public static bool getDisc = false;

    public static string job = "1";

    //endings
    public static bool rat = false;
    public static bool killAttackerUnNoticed = false;
    public static bool killAttackerNoticed = false;
    public static bool escaped = false;
    //
    public static bool attack_cellmate = false;
    public static bool kill_cellmate = false;
    //
    public static bool attack_cook = false;
    public static bool kill_cook = false;
    //
    public static bool attack_informant = false;
    public static bool kill_informant = false;
    
    public static bool attack_guard = false;
    public static bool kill_guard = false;
    //
    public static bool attack_warden = false;
    public static bool kill_warden = false;
    //
    public static bool attack_gang_leader = false;
    public static bool kill_gang_leader = false;
    //
    public static bool attack_gang_lackey = false;
    public static bool kill_gang_lackey = false;

    public static void reset()
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
