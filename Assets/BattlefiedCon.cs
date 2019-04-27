using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class  BattlefiedCon : MonoBehaviour
{
    public GameObject ListP1Troop, ListP2Troop;
    public GameObject AttackPartical;
    public HPFieldCon FieldDetail;
    public GameObject NPCdetailbatlle;
    public GameObject BlackBlock;

    public GameObject Field;
    List<Vector2> TempList;
    List<Vector2> TempList2;
    public List<Vector2> Test;
    public List<SlotBattle> Test2;

    public int[,] Matrix;

    public NPCFullBody BodyLeft;
    public NPCFullBody BodyRight;
    public List<SlotBattle> HighLightingSlots;

    public bool Moving;

    public int MaxSpeedTurn;
    public Text TurnText;
    public int TurnCount;
    public List<NPCInBattlePro> Temp, TempForTurn,TempForTurn2;

    public GameObject PreNPC, PreTurn;
    public GameObject ListSlot;
    public GameObject ListTurn;
    public List<NPCInBattlePro> ListMyNPC;
    public List<NPCInBattlePro> ListEnemyNPC;
    public List<NPCInBattlePro> AllNPC;
    [SerializeField]
    private SlotBattle hoverSlot;
    public SlotBattle HoverSlot
    {
        get { return hoverSlot; }
        set { hoverSlot = value; }      
    }
    public NPCInBattle NPCNow {
        get {return nPCNow; }
        set {
            nPCNow = value;
            if (value!= null)
            {
               // nPCNow.Shade.gameObject.SetActive(true);
            }
        }
    }
    [SerializeField]
    private NPCInBattle nPCNow;
    //public 



    // Start is called before the first frame update
    void Start()
    {
      /*  int height = 18;
        int width = 18;

        Matrix = new int[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == i + 1 || j == i - 1 || j == i + 3 || j == i - 3)
                {
                    Matrix[i, j] = 1;
                }
                // Matrix[i, j]
            }
        }
        */




        foreach (var item in ListMyNPC)
        {
            AllNPC.Add(item);
        }
        foreach (var item in ListEnemyNPC)
        {
            AllNPC.Add(item);
        }


        foreach (NPCInBattlePro item in ListMyNPC)
        {           
            GameObject a = Instantiate(PreNPC, ListSlot.transform.GetChild(item.Index));
            a.transform.localPosition = Vector3.zero;
            a.GetComponent<NPCInBattle>().NPCPro = item;
            a.GetComponent<NPCInBattle>().IconClass.sprite = item.Hero.Class.Pic;
            a.GetComponent<NPCInBattle>().BattleBody.sprite = item.Hero.BattleBody;
            a.GetComponent<NPCInBattle>().Filler.Value = (float)item.HP / item.MaxHP;
            a.GetComponent<NPCInBattle>().NPCPro.TimeSpeed = Random.Range(0, MaxSpeedTurn);
        }
        foreach (NPCInBattlePro item in ListEnemyNPC)
        {
            GameObject a = Instantiate(PreNPC, ListSlot.transform.GetChild(item.Index));
            a.transform.localPosition = Vector3.zero;
            a.GetComponent<NPCInBattle>().NPCPro = item;
            a.GetComponent<NPCInBattle>().IconClass.sprite = item.Hero.Class.Pic;
            a.GetComponent<NPCInBattle>().BattleBody.sprite = item.Hero.BattleBody;
            a.GetComponent<NPCInBattle>().Filler.Value = (float)item.HP / item.MaxHP;
            a.GetComponent<NPCInBattle>().NPCPro.TimeSpeed = Random.Range(0, MaxSpeedTurn);
            a.GetComponent<NPCInBattle>().BattleBody.transform.localScale = new Vector2(-1, 1);

        }

        CheckListTempForTurn();
        foreach (NPCInBattlePro item in TempForTurn)
        {

            GameObject a = Instantiate(PreTurn, ListTurn.transform);
            a.GetComponent<TurnCon>().NameNPC.text = item.Hero.name;

        }
        ListSlot.transform.GetChild(TempForTurn[0].Index).Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>().WhiteBlink();
        NPCNow = ListSlot.transform.GetChild(TempForTurn[0].Index).Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>();
        //  CheckTurn();
        // CheckTurn();
        MovePreNPCNow(NPCNow.NPCPro.Hero.Class);
        BodyMoveIn();
    }

     

    void CheckTurn()
    {

        Temp = new List<NPCInBattlePro>();


        foreach (NPCInBattlePro item in AllNPC)
        {
            if (item.TimeSpeed <= MaxSpeedTurn)
            {
                item.TimeSpeed += item.Spd;
            }
            else
            {
                Temp.Add(item);
                item.TimeSpeed -= MaxSpeedTurn;
            }
        }

      //  SortByInt t = new SortByInt();

        //  TempWithOrder = new List<NPCInBattlePro>(Temp);

        // TempWithOrder.Sort(t);
        // TempWithOrder.Reverse();

        Temp.Shuffle();
       

        if (Temp.Count >0)
        {
           // NPCNow = ListSlot.transform.GetChild(Temp[0].Index).GetChild(0).GetComponent<NPCInBattle>();
          //  ListSlot.transform.GetChild(Temp[0].Index).GetChild(0).GetComponent<NPCInBattle>().Shade.gameObject.SetActive(true);
        }





    }
    public void SkipTurn()
    {
        for (int i = 0; i < AllNPC.Count; i++) // Xoa nhung NPC Death
        {
            if (AllNPC[i].HP<=0)
            {
                Debug.Log(AllNPC[i].Hero.name);
                TempForTurn.Remove(AllNPC[i]);
                TempForTurn2.Remove(AllNPC[i]);
                Temp.Remove(AllNPC[i]);
                AllNPC.Remove(AllNPC[i]);
            }
        }

        NPCNow.Shade.gameObject.SetActive(false);

        TurnCount -= 1;
        if (AllNPC.Any(z => z.TimeSpeed >= 0))
        {

        }
        else
        {
            foreach (var item in AllNPC)
            {
                item.TimeSpeed += item.Spd;
            }
        }
        

        foreach (Transform item in ListTurn.transform)
        {
            Destroy(item.gameObject);
        }

        NPCInBattlePro A = TempForTurn[0];

        TempForTurn[0].TimeSpeed -= MaxSpeedTurn;
        TempForTurn[0].TurnCount += 1;
        TempForTurn.Remove(TempForTurn[0]);

        
        // Destroy(ListTurn.transform.GetChild(0).gameObject);


        TempForTurn2 = new List<NPCInBattlePro>(TempForTurn);       

        CheckListTempForTurn();

        

        int b = TempForTurn.IndexOf( TempForTurn.Find(x => x ==A) );

        TempForTurn = new List<NPCInBattlePro>(TempForTurn2);

        TempForTurn.Insert(b, A); // new Turn guy

        foreach (NPCInBattlePro item in TempForTurn)
        {

            GameObject a = Instantiate(PreTurn, ListTurn.transform);
            a.GetComponent<TurnCon>().NameNPC.text = item.Hero.name;

        }

        ListSlot.transform.GetChild(TempForTurn[0].Index).Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>().WhiteBlink();
        NPCNow = ListSlot.transform.GetChild(TempForTurn[0].Index).Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>();

        MovePreNPCNow(NPCNow.NPCPro.Hero.Class);
        BodyMoveIn();
    }

    public void BodyMoveIn()
    {
        BodyLeft.gameObject.SetActive(false);
        BodyRight.gameObject.SetActive(false);

        if (ListMyNPC.Contains(NPCNow.NPCPro))
        {
            BodyLeft.gameObject.SetActive(true);

            BodyLeft.GetComponent<Image>().sprite = NPCNow.NPCPro.Hero.Fullbody;
            BodyLeft.MoveIn();           
        }
        else
        {
            BodyRight.gameObject.SetActive(true);

            BodyRight.GetComponent<Image>().sprite = NPCNow.NPCPro.Hero.Fullbody;
            BodyRight.MoveIn();
        }
    }

    public void CheckListTempForTurn()
    {
        List<int> A = new List<int>();
        TempForTurn = new List<NPCInBattlePro>();
        foreach (var item in AllNPC)
        {
            A.Add(item.TimeSpeed);
        }

        while (TempForTurn.Count< AllNPC.Count)
        {
            if (Temp.Count == 0)
            {
                CheckTurn();
               // TurnCount -= 1;
            }
            else
            {
                foreach (var item in Temp)
                {
                    if (TempForTurn.Contains(item) == false)
                    {
                        TempForTurn.Add(item);                        
                    }
                }
                Temp = new List<NPCInBattlePro>();
            }
        }
        

      //  A = new List<int>();
        for (int i = 0; i < AllNPC.Count; i++)
        {
            AllNPC[i].TimeSpeed = A[i];
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {

            MovePreNPCNow(NPCNow.NPCPro.Hero.Class);
        }

        

        TurnText.text = TurnCount.ToString();
    }
    public void MovePreNPCNow(ClassNPC Class)
    {
        Moving = true;
        HighLightingSlots = new List<SlotBattle>();
        OffALLBlinkSlot();

        if (Class.name == "Swordsman")
        {
            HighLightingSlots.AddRange(NormalMoving());
            HighLightingSlots.AddRange(WarriorlAtt());
        }
        else if (Class.name == "Archer")
        {
            HighLightingSlots.AddRange(NormalMoving());
            HighLightingSlots.AddRange(ArcherAtt());
           // HighLightingSlots.AddRange(MageHeal());
        }




        foreach (var item in HighLightingSlots)
        {
            CheckForHighLight(item);
        }      
    }

    public List<SlotBattle> NormalMoving()
    {
        List<SlotBattle> Temp = new List<SlotBattle>();

        foreach (var item in NPCNow.GetSlot().GetAdjSlotNoNPC()) 
        {
            bool temp = false;
            foreach (var Jtem in item.GetSlotAttBoth(1))
            {
                if (Jtem.CheckNoNPC() == false && CheckIfSameTeam(NPCNow.NPCPro, Jtem.FindNPCInSlot().NPCPro) == false)
                {
                    temp = true; break;
                }
            }

            if (temp == false)
            {
                Temp.Add(item);
            }
        }
        foreach (var item in NPCNow.GetSlot().GetSlotAttBoth(1))
        {
            if (Temp.Contains(item) == false)
            {
                Temp.Add(item);
            }
        }

        return Temp;
    }
    public List<SlotBattle> WarriorlAtt()
    {
        List<SlotBattle> Temp = new List<SlotBattle>();

        foreach (var item in NPCNow.GetSlot().GetSlotAttBoth(2))
        {
            if (item.CheckNoNPC() == false)
            {
                Temp.Add(item);
            }
        }
        return Temp;
    }
    public List<SlotBattle> ArcherAtt()
    {
        List<SlotBattle> Temp = new List<SlotBattle>();

        foreach (var item in NPCNow.GetSlot().GetSlotAttBoth(3))
        {
            if (CheckWHatSlotGot(NPCNow.NPCPro,item) == "Enemy")
            {
                Temp.Add(item);
            }
        }
        return Temp;
    }
    public List<SlotBattle> MageHeal()
    {
        List<SlotBattle> Temp = new List<SlotBattle>();

        foreach (var item in NPCNow.GetSlot().GetSlotAttBoth(5))
        {
            if (item.CheckNoNPC() == false)
            {
                Temp.Add(item);
            }
        }
        return Temp;
    }




    public void Move()
    {
        StartCoroutine(ForMove());
    }

    IEnumerator ForMove()
    {
        NPCNow.transform.SetParent(HoverSlot.transform);
        NPCNow.NPCPro.Index = HoverSlot.transform.GetSiblingIndex();
        NPCNow.Shade.gameObject.SetActive(false);
        OffALLBlinkSlot();
        NPCNow.Move(NPCNow.transform.localPosition, Vector2.zero,0.5f);
        yield return new WaitForSeconds(0.5f);
        SkipTurn();

    }

    public void AttackNormal()
    {

        FieldBattle();


        int a = HoverSlot.FindNPCInSlot().NPCPro.HP;
        int b = NPCNow.NPCPro.HP;
        HoverSlot.FindNPCInSlot().NPCPro.HP -= (int)((((float)NPCNow.NPCPro.Att + 1) / (HoverSlot.FindNPCInSlot().NPCPro.Def + 1)) * b / 10);
        NPCNow.NPCPro.HP -= (int)((((float)HoverSlot.FindNPCInSlot().NPCPro.Att + 1) / (NPCNow.NPCPro.Def + 1)) * a / 10);
        SkipTurn();
        MovePreNPCNow(NPCNow.NPCPro.Hero.Class);

    }
    public void FieldBattle()
    {
        StartCoroutine(ForFieldBattle());
    }

    public IEnumerator ForFieldBattle()
    {
        StartCoroutine(TurnOnandOffObjectAfterSec(BlackBlock, 0, 3));
        StartCoroutine(TurnOnandOffObjectAfterSec(Field, 0, 3));
        StartCoroutine(TurnOnandOffObjectAfterSec(NPCdetailbatlle, 0, 3));

        if (CheckIfNPCIsPlayer())
        {
            FieldDetail.P1Pic.sprite = NPCNow.NPCPro.Hero.BattleBody;
            FieldDetail.P2Pic.sprite = HoverSlot.FindNPCInSlot().NPCPro.Hero.BattleBody;
            FieldDetail.P1name.text = NPCNow.NPCPro.Hero.name.ToString();
            FieldDetail.P2name.text = HoverSlot.FindNPCInSlot().NPCPro.Hero.name.ToString();
            FieldDetail.P1HP.text = NPCNow.NPCPro.HP.ToString();
            FieldDetail.P2HP.text = HoverSlot.FindNPCInSlot().NPCPro.HP.ToString();

            yield return new WaitForSeconds(1);
            GameObject a = Instantiate(AttackPartical, Field.transform);
            foreach (Transform item in ListP2Troop.transform) //shake
            {
                item.transform.GetComponent<ShakingClass>().ShakeMe(5);
            }

        }
        else
        {
            FieldDetail.P2Pic.sprite = NPCNow.NPCPro.Hero.BattleBody;
            FieldDetail.P1Pic.sprite = HoverSlot.FindNPCInSlot().NPCPro.Hero.BattleBody;
            FieldDetail.P2name.text = NPCNow.NPCPro.Hero.name.ToString();
            FieldDetail.P1name.text = HoverSlot.FindNPCInSlot().NPCPro.Hero.name.ToString();
            FieldDetail.P2HP.text = NPCNow.NPCPro.HP.ToString();
            FieldDetail.P1HP.text = HoverSlot.FindNPCInSlot().NPCPro.HP.ToString();

            yield return new WaitForSeconds(1);
            GameObject a = Instantiate(AttackPartical, Field.transform);
            a.transform.localScale = new Vector3(-a.transform.localScale.x, a.transform.localScale.y, a.transform.localScale.z);
            foreach (Transform child in a.transform)
            {
                child.GetComponent<ParticleSystemRenderer>().flip = new Vector3(1, 0, 0);
            }
            foreach (Transform item in ListP1Troop.transform) //shake
            {
                item.transform.GetComponent<ShakingClass>().ShakeMe(5);
            }
        }
    }

    public void AttackRange()
    {
        FieldBattle();


        // Field.SetActive(true);

        int a = HoverSlot.FindNPCInSlot().NPCPro.HP;
        int b = NPCNow.NPCPro.HP;
        HoverSlot.FindNPCInSlot().NPCPro.HP -= (int)((((float)NPCNow.NPCPro.Att + 1) / (HoverSlot.FindNPCInSlot().NPCPro.Def + 1)) * b / 10);
        SkipTurn();
        MovePreNPCNow(NPCNow.NPCPro.Hero.Class);
    }
    public void Support()
    {

    }

    public IEnumerator TurnOnandOffObjectAfterSec(GameObject Obj ,float PreW8Time, float W8Time)
    {
        yield return new WaitForSeconds(PreW8Time);
        Obj.SetActive(true);
        yield return new WaitForSeconds(W8Time);
        Obj.SetActive(false);
    }
    public IEnumerator CreateAndDestroyObjectAfterSec(GameObject Obj, float PreW8Time, float W8Time)
    {
        yield return new WaitForSeconds(PreW8Time);
        
        yield return new WaitForSeconds(W8Time);
        Obj.SetActive(false);
    }


    public void OffALLBlinkSlot()
    {
        HighLightingSlots = new List<SlotBattle>();
        foreach (Transform item in ListSlot.transform)
        {
            item.GetComponent<SlotBattle>().BlinkingColor.gameObject.SetActive(false);
        }
    }

    public void CheckForHighLight(SlotBattle Slot)
    {
        if (Slot.CheckNoNPC() || Slot.FindNPCInSlot().NPCPro.HP <=0)
        {
            Slot.BlinkingColor.WhiteBlink();
        }
        else
        {
            if (CheckIfSameTeam(NPCNow.NPCPro, Slot.transform.Find("NPCInbattle(Clone)").GetComponent<NPCInBattle>().NPCPro ))
            {
                if (NPCNow.GetSlot() != Slot)
                {
                    Slot.BlinkingColor.GreenBlink(); // Ally
                }
                else
                {
             //       Slot.BlinkingColor.YellowBlink(); // Self
                }
            }
            else
            {
                Slot.BlinkingColor.RedBlink();
            }
        }
    }
    
    public bool CheckIfSameTeam(NPCInBattlePro NPC1, NPCInBattlePro NPC2)
    {
        if (ListMyNPC.Contains(NPC1))
        {
            if (ListMyNPC.Contains(NPC2))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        else
        {
            if (ListMyNPC.Contains(NPC2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public string CheckWHatSlotGot(NPCInBattlePro NPC, SlotBattle Slot) // kiem tra slot co gi
    {
        if (Slot.CheckNoNPC())
        {
            return "No";
        }
        else
        {
            if (CheckIfSameTeam(NPC, Slot.FindNPCInSlot().NPCPro))
            {
                if (NPCNow.GetSlot() == Slot)
                {
                    return "Self";
                }
                else
                {
                    return "Ally";
                }
            }
            else
            {
                return "Enemy";
            }
        }
    }

    
    public void CheckSlotCanMove(int Index)
    {
        SlotBattle SlotNeed = ListSlot.transform.GetChild(Index).GetComponent<SlotBattle>();
        int StepCount = 1;
        int PathIndex = 0;

        List<SlotBattle> Slots = new List<SlotBattle>();
        Test = new List<Vector2>();
        OffALLBlinkSlot();

        Test.Add(new Vector2(NPCNow.transform.parent.GetSiblingIndex(), 0));
        foreach (var item in NPCNow.GetSlot().GetAdjSlotNoNPC())
        {
            if (Slots.Contains(item) == false)
            {
                Slots.Add(item);
                Test.Add(new Vector2(item.transform.GetSiblingIndex(), StepCount));
            }
        }

        int AddCount = 0;
        int AddCount2 = 0;// so lan add de kiem tra da cung duong chua
        while (Slots.Contains(SlotNeed)!=true)
        {
            AddCount = AddCount2;
            StepCount += 1;
            int tempint = Slots.Count;
            for (int i = 0; i < tempint; i++)
            {
                foreach (var item in Slots[i].GetAdjSlotNoNPC())
                {
                    if (Slots.Contains(item) == false)
                    {
                        Slots.Add(item);
                        Test.Add(new Vector2(item.transform.GetSiblingIndex(), StepCount));
                        AddCount2 += 1;
                    }
                }
            }

            if (AddCount2 == AddCount)
            {
                Debug.Log("tac duong roi anh ey");
                break;
            }
        }


        //  Tim Duong ngan nhat
        int temp = StepCount-1;
        SlotBattle tempSlot = SlotNeed;
        Test2 = new List<SlotBattle>();
        for (int i = 1; i < StepCount; i++)
        {
            TempList = new List<Vector2>();
            TempList2 = new List<Vector2>();

            TempList = Test.FindAll(x => x.y == temp);
            foreach (var item in TempList)
            {
                if (tempSlot.GetAdjSlotNoNPC().Contains(GetSlotWithIndex((int)item.x)))
                {
                    TempList2.Add(item);
                }
            }
            int ran = Random.Range(0, TempList2.Count);
            Test2.Add(GetSlotWithIndex((int)TempList2[ran].x));

            tempSlot = GetSlotWithIndex((int)TempList2[ran].x);
            temp -= 1;
          //  temp
        }

        foreach (var item in Test2)
        {
            item.BlinkingColor.WhiteBlink();
        }

    }

    public SlotBattle GetSlotWithIndex(int Index)
    {
        return ListSlot.transform.GetChild(Index).GetComponent<SlotBattle>();
    }

    public int GridToId(Vector2 Grid)
    {
        return (int)(Grid.y * 3 + Grid.x);
    }

    public bool CheckIfNPCIsPlayer()
    {
        if (ListMyNPC.Contains(NPCNow.NPCPro))
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}















[System.Serializable]
public class NPCInBattlePro 
{
    public NPC Hero;
    public int HP;
    public int MaxHP;
    public int Att, Def, Int, Spd;
    public int Index;
    public int TimeSpeed;
    
    public int TurnCount;
}

public class SortByInt : IComparer<NPCInBattlePro>
{
    public int Compare(NPCInBattlePro x, NPCInBattlePro y)
    {
        return x.TimeSpeed.CompareTo(y.TimeSpeed);
    }
}


     

