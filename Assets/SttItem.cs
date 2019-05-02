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
        StartColor = GetComponent<Image>().color;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (ItemProgress.GameItem != null && ItemProgress.Unlocked)
        {

            ItemName.text = ItemProgress.GameItem.name;
            if (ItemProgress.GameItem.TypeItem == Item.Type.Item)
            {
                Amount.text = ItemProgress.Amount.ToString();

            }
            ItemIcon.sprite = ItemProgress.GameItem.Pic;
        }
        else
        {
            ItemName.text = Con.UnknownNameItem;
            Amount.text = "";
            ItemIcon.sprite = Con.UnknownItem;
        }
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
