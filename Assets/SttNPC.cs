using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SttNPC : MonoBehaviour, IPointerDownHandler
{

    public NPCPro NPCProgress;
    public Text NPCName, HP, MaxHP, Att, Def, Spd, Int;
    public Image ClassIcon;

    public TroopMenuCon Con;

    public Color StartColor;
    // Start is called before the first frame update
    void Start()
    {
        StartColor = GetComponent<Image>().color;

        NPCName.text = NPCProgress.Hero.name;
        HP.text = NPCProgress.HP.ToString();
        MaxHP.text = NPCProgress.MaxHP.ToString();
        Att.text = NPCProgress.Hero.Att.ToString();
        Def.text = NPCProgress.Hero.Def.ToString();
        Spd.text = NPCProgress.Hero.Spd.ToString();
        Int.text = NPCProgress.Hero.Int.ToString();

        ClassIcon.sprite = NPCProgress.Hero.Class.Pic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForMouseEnter()
    {
        
        Con.Hovering = this;


    }
    public void ForMouseOut()
    {
        Con.Hovering = null;
    }
    public void ForMouseClickUp()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Con.Selected)
            {
                Con.Selected.GetComponent<Image>().color = StartColor;
            }

            Con.Selected = this;

            Con.Selected.GetComponent<Image>().color = Con.HL;
            //  Debug.Log("Left click");
        }

        else if (eventData.button == PointerEventData.InputButton.Middle) ;
        //   Debug.Log("Middle click");
        else if (eventData.button == PointerEventData.InputButton.Right) ;
          //  Debug.Log("Right click");
    }
}
