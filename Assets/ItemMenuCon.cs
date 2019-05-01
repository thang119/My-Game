using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemMenuCon : MonoBehaviour
{
    public enum Mode {Weapon, Item, Mist }
    public Mode TypeMode;
    public SttItem Hovering;
    public SttItem Selected;

    public Color HL;

    public MainClass Main;
    public GameObject Preb;
    public GameObject ListWeapon, ListItem, ListMist;

    public List<GameObject> ListMode;
  //  public 

    // Start is called before the first frame update
    private void OnEnable()
    {
        List<ItemPro> TempList = Main.ItemList.FindAll(x => x.GameItem.TypeItem == Item.Type.Weapon);
        List<ItemPro> TempList2 = Main.ItemList.FindAll(x => x.GameItem.TypeItem == Item.Type.Item);
        List<ItemPro> TempList3 = Main.ItemList.FindAll(x => x.GameItem.TypeItem == Item.Type.Mist);

        foreach (var item in TempList)
        {
            ListWeapon.transform.GetChild(item.GameItem.ID).GetComponent<SttItem>().ItemProgress = item;
        }
        foreach (var item in TempList2)
        {
            ListItem.transform.GetChild(item.GameItem.ID).GetComponent<SttItem>().ItemProgress = item;
        }
        foreach (var item in TempList3)
        {
            ListMist.transform.GetChild(item.GameItem.ID).GetComponent<SttItem>().ItemProgress = item;
        }
    }
    private void OnDisable()
    {
     //   foreach (Transform child in List.transform)
        {
           // Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1) && Selected)
        {
            Selected.GetComponent<Image>().color = Selected.StartColor;
            Selected = null;

        }
        if (TypeMode == Mode.Weapon)
        {

        }
        

    }

    public void OffAllModeObj()
    {
        foreach (var item in ListMode)
        {
            item.SetActive(false);
        }
    }
}
