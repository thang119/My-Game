using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TroopMenuCon : MonoBehaviour
{
    public SttNPC Hovering;
    public SttNPC Selected;

    public Color HL;

    public MainClass Main;
    public GameObject Preb;
    public GameObject List;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (var item in Main.HeroList)
        {
            GameObject a = Instantiate(Preb, List.transform);
            a.GetComponent<SttNPC>().NPCProgress = item;
        }
    }
    private void OnDisable()
    {
        foreach (Transform child in List.transform)
        {
            Destroy(child.gameObject);
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
    }

    
}
