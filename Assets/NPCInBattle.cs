using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInBattle : MonoBehaviour
{
    Canvas Can;
    //  bool Death;
    public bool Moving;
    public Vector2 StartPos,EndPos;
    public float TimeMoving,TimeMovingX;
    

    public Color WhiteStart, WhiteEnd;
    public Color RedStart, RedEnd;
    public Color GreenStart, GreenEnd;


    public NPCInBattlePro NPCPro;
    


    public Text HPText;
    public Image IconClass, BattleBody, Shade;
    public FillerClass Filler;
    public GameObject ListGrid;

    private void Start()
    {
        Can = GetComponent<Canvas>();

        Shade.sprite = NPCPro.Hero.BattleBody;
    }

    private void Update()
    {
        HPText.text = NPCPro.HP.ToString();
        Filler.Value = (float)NPCPro.HP / NPCPro.MaxHP;
        if (NPCPro.HP <= 0)
        {

            Destroy(gameObject);

        }

        if (Moving)
        {
            TimeMovingX += Time.deltaTime;
            transform.localPosition = Vector2.Lerp(StartPos, EndPos, TimeMovingX / TimeMoving);
        }

      //  NPCPro.Index = transform.parent.GetSiblingIndex();
    }

    public void Move(Vector2 Pos1,Vector2 Pos2, float t)
    {
        StartCoroutine(ForMove(Pos1, Pos2, t));
    }
    IEnumerator ForMove(Vector2 Pos1,Vector2 Pos2, float t)
    {
        if (!Moving)
        {
            Can.sortingOrder += 1;
            TimeMovingX = 0;
            StartPos = Pos1;
            EndPos = Pos2;
            TimeMoving = t;
            Moving = true;
        }
        yield return new WaitForSeconds(t);
        Can.sortingOrder -= 1;
        Moving = false;
    }
    public void WhiteBlink()
    {
        Shade.GetComponent<ColorBlinkingClass>().ResetVars();
      //  Shade.GetComponent<Image>().color = WhiteStart;
        Shade.GetComponent<ColorBlinkingClass>().CorStart = WhiteStart;
        Shade.GetComponent<ColorBlinkingClass>().Cor2End = WhiteEnd;
        Shade.gameObject.SetActive(true);
    }
    public void RedBlink()
    {
        Shade.GetComponent<ColorBlinkingClass>().ResetVars();
      //  Shade.GetComponent<Image>().color = WhiteStart;
        Shade.GetComponent<ColorBlinkingClass>().CorStart = RedStart;
        Shade.GetComponent<ColorBlinkingClass>().Cor2End = RedEnd;
        Shade.gameObject.SetActive(true);
    }
    public void GreenBlink()
    {
        Shade.GetComponent<ColorBlinkingClass>().ResetVars();
     //   Shade.GetComponent<Image>().color = WhiteStart;
        Shade.GetComponent<ColorBlinkingClass>().CorStart = GreenStart;
        Shade.GetComponent<ColorBlinkingClass>().Cor2End = GreenEnd;
        Shade.gameObject.SetActive(true);
    }

    public SlotBattle GetSlot()
    {
        return transform.parent.GetComponent<SlotBattle>();
    }
}
