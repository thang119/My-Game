using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailItem : MonoBehaviour
{
    public Image Icon;
    public Text Description;
    public ItemMenuCon Con;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Con.Selected && Con.Selected.ItemProgress.GameItem != null && Con.Selected.ItemProgress.Unlocked)
        {
            Icon.sprite = Con.Selected.ItemProgress.GameItem.Pic;
            Description.text = Con.Selected.ItemProgress.GameItem.Description;
        }
        else
        {
            Icon.sprite = null;
            Description.text = "";
        }
        

    }
}
