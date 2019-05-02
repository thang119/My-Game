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

    public Sprite UnknownItem;
    public string UnknownNameItem;
  //  public 

    // Start is called before the first frame update
    private void Start()
    {
        
        foreach (var item in Main.EquipmentList)
        {
            Instantiate(Preb, ListWeapon.transform);           
            ListWeapon.transform.GetChild(Main.EquipmentList.IndexOf(item)).GetComponent<SttItem>().ItemProgress = item;
        }
        foreach (var item in Main.ItemList)
        {
            Instantiate(Preb, ListItem.transform);
            ListItem.transform.GetChild(Main.ItemList.IndexOf(item)).GetComponent<SttItem>().ItemProgress = item;
        }
        foreach (var item in Main.MistList)
        {
            Instantiate(Preb, ListMist.transform);
            ListMist.transform.GetChild(Main.MistList.IndexOf(item)).GetComponent<SttItem>().ItemProgress = item;
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
