using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyArmyCon : MonoBehaviour
{
    public TroopMenuCon Menu;
    public Image CharMenu;
    SttNPC MySlected;
    Color StartColor;
    // Start is called before the first frame update
    void Start()
    {
        StartColor = Menu.Preb.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.Selected && MySlected != Menu.Selected)
        {

            MySlected = Menu.Selected;
            CharMenu.gameObject.SetActive(false);
            CharMenu.sprite = Menu.Selected.NPCProgress.Hero.Fullbody;
            CharMenu.gameObject.SetActive(true);
        }
        else if (!Menu.Selected)
        {
            MySlected = null;
            CharMenu.gameObject.SetActive(false);


        }

    }
}
