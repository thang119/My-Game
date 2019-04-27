using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotBattle : MonoBehaviour
{
    public BattlefiedCon Con;

    public ColorBlinkingClass BlinkingColor;
    public Vector2 Grid;
    public List<SlotBattle> AdjSlot;
    // Start is called before the first frame update
    void Start()
    {
        Grid = new Vector2(transform.GetSiblingIndex() % 3, transform.GetSiblingIndex() / 3);



        GetListAdjSlot();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnEnter()
    {
        Con.HoverSlot = this;
    }

    public void ForOnMouseUp()
    {
        if (Con.HighLightingSlots.Contains(Con.HoverSlot))
        {
            if (Con.CheckWHatSlotGot(Con.NPCNow.NPCPro, Con.HoverSlot) == "No")
            {
                Con.Move();              
            }
            else if (Con.CheckWHatSlotGot(Con.NPCNow.NPCPro, Con.HoverSlot) == "Ally")
            {
                Con.Support();
            }
            else if (Con.CheckWHatSlotGot(Con.NPCNow.NPCPro, Con.HoverSlot) == "Enemy")
            {
                if (Con.NPCNow.NPCPro.Hero.Class.name == "Archer")
                {
                    Con.AttackRange();
                }
                else if (Con.NPCNow.NPCPro.Hero.Class.name == "Swordsman")
                {
                    Con.AttackNormal();

                }
                
            }

        }
    }
        
    public bool CheckNoNPC()
    {
        if (transform.Find("NPCInbattle(Clone)"))
        {
            if (transform.Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>().NPCPro.HP > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {

            return true;
        }
    }

    public NPCInBattle FindNPCInSlot()
    {
        return transform.Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>();
    }

    void GetListAdjSlot()
    {
        if (Grid.x + 1 < 3)
        {
            AdjSlot.Add(transform.parent.GetChild((int)(Grid.y * 3 + Grid.x + 1)).GetComponent<SlotBattle>());
        }
        if (Grid.x - 1 >= 0)
        {
            AdjSlot.Add(transform.parent.GetChild((int)(Grid.y * 3 + Grid.x - 1)).GetComponent<SlotBattle>());

        }
        if (Grid.y + 1 < 6)
        {
            AdjSlot.Add(transform.parent.GetChild((int)((Grid.y + 1) * 3 + Grid.x)).GetComponent<SlotBattle>());
        }
        if (Grid.y - 1 >= 0)
        {
            AdjSlot.Add(transform.parent.GetChild((int)((Grid.y - 1) * 3 + Grid.x)).GetComponent<SlotBattle>());

        }
    }

     public List<SlotBattle> GetAdjSlotNoNPC()
     {
        List<SlotBattle> temp = new List<SlotBattle>();
        foreach (var item in AdjSlot)
        {
            if (item.CheckNoNPC())
            {
                temp.Add(item);
            }
        }
        return temp;
     }

    

    public List<SlotBattle> GetSlotAttBoth(int Range)
    {
        List<SlotBattle> temp = new List<SlotBattle>();

        for (int i = 0; i < Range; i++)
        {
            if (Grid.y + i < 6)
            {
                temp.Add(transform.parent.GetChild((int)((Grid.y + i) * 3 + 0)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y + i) * 3 + 1)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y + i) * 3 + 2)).GetComponent<SlotBattle>());
            }
            if (Grid.y - i >= 0)
            {
                temp.Add(transform.parent.GetChild((int)((Grid.y - i) * 3 + 0)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y - i) * 3 + 1)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y - i) * 3 + 2)).GetComponent<SlotBattle>());
            }
        }
        
        

        return temp;
    }
    public List<SlotBattle> GetSlotAttLeft(int Range)
    {
        List<SlotBattle> temp = new List<SlotBattle>();
        for (int i = 0; i < Range; i++)
        {
            if (Grid.y - i >= 0)
            {
                temp.Add(transform.parent.GetChild((int)((Grid.y - i) * 3 + 0)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y - i) * 3 + 1)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y - i) * 3 + 2)).GetComponent<SlotBattle>());
            }
        }
        return temp;
    }
    public List<SlotBattle> GetSlotAttRight(int Range)
    {
        List<SlotBattle> temp = new List<SlotBattle>();
        for (int i = 0; i < Range; i++)
        {
            if (Grid.y + i >= 0)
            {
                temp.Add(transform.parent.GetChild((int)((Grid.y + i) * 3 + 0)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y + i) * 3 + 1)).GetComponent<SlotBattle>());
                temp.Add(transform.parent.GetChild((int)((Grid.y + i) * 3 + 2)).GetComponent<SlotBattle>());
            }
        }
        return temp;
    }


    public int GetIndex()
    {
        return transform.GetSiblingIndex();
    }

}
