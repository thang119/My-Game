using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SttItem : MonoBehaviour, IPointerDownHandler
{
    public ItemPro ItemProgress;
    public Text ItemName, Amount;
    public Image ItemIcon;

    public ItemMenuCon Con;

    public Color StartColor;
    // Start is called before the first frame update
    void Start()
    {
        if (ItemProgress.GameItem!=null)
        {
            StartColor = GetComponent<Image>().color;

            ItemName.text = ItemProgress.GameItem.name;
            Amount.text = ItemProgress.Amount.ToString();

            ItemIcon.sprite = ItemProgress.GameItem.Pic;
        }
        
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
