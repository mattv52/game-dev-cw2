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

    
}
