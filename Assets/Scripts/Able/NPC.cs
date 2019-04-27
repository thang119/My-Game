using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New NPC Data", menuName = "NPC Data")]

public class NPC : ScriptableObject
{
    public Sprite Fullbody, Face, BattleBody, AttackBody;
    public ClassNPC Class;

   // public enum Class {None, Warrior, Archer, FootSoldier, Gunner, WhiteMage, BlackMage, Cavary}
    public int Att, Def, Int, Spd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
