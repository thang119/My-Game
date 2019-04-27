using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorBlinkingClass : MonoBehaviour
{
    // public float test;
    Image Pic;
    public Color CorStart;
    Color TempCorStart;

    public Color Cor2End;
    Color TempCor2End;


  //  float StartTime;

    public float StartSec;
    float Sec;

    float CurrentSec;

   // public float RenewSec;
    float JourneySec; // den 1 thi xong

    // Start is called before the first frame update
    void Start()
    {
        
       // StartSec = 1;


        Pic = GetComponent<Image>();
      //  StartTime = Time.time; // Co cung dc ko co cung ko sao
        Sec = StartSec;
        TempCorStart = CorStart;
        TempCor2End = Cor2End;
     //   Cor2 = new Color(CorStart.r, CorStart.g, CorStart.b, 0);
    }

    // Update is called once per frame
    void Update()
    {

        CurrentSec += Time.deltaTime;

        //test += Time.deltaTime;
        if (CurrentSec > Sec)
        {
            Sec += StartSec;
            float Temp = (((Sec / StartSec)+1) % 2); // Check If chan le
            if (Temp == 0)
            {
                TempCorStart = CorStart;
                TempCor2End = Cor2End;
                
            }
            else
            {
                TempCorStart = Cor2End;
                TempCor2End = CorStart;
            }
        }
        JourneySec =(CurrentSec% StartSec) / StartSec ;     
        Pic.color = Color.Lerp(TempCorStart, TempCor2End, JourneySec);
       
    
    

    }

    public void ResetVars()
    {
        Sec = 0;
        CurrentSec = 0;
        JourneySec = 0;
    }
    public void WhiteBlink()
    {
        ResetVars();
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
        CorStart = new Color(1, 1, 1, 0);
        Cor2End = new Color(1, 1, 1, 0.4f);
        TempCorStart = CorStart;
        TempCor2End = Cor2End;

        gameObject.SetActive(true);
    }
    public void RedBlink()
    {
        ResetVars();
        GetComponent<Image>().color = new Color(1, 0, 0, 0);
        CorStart = new Color(1, 0, 0, 0);
        Cor2End = new Color(1, 0, 0, 0.4f);
        TempCorStart = CorStart;
        TempCor2End = Cor2End;

        gameObject.SetActive(true);
    }
    public void GreenBlink()
    {
        ResetVars();
        GetComponent<Image>().color = new Color(0, 1, 0, 0);
        CorStart = new Color(0, 1, 0, 0);
        Cor2End = new Color(0, 1, 0, 0.4f);
        TempCorStart = CorStart;
        TempCor2End = Cor2End;

        gameObject.SetActive(true);
    }
}
