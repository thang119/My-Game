using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillerClass : MonoBehaviour
{
  //  public GameObject controlObj;
    [SerializeField][Range(0,1)]
    private float value;


    public float Value
    {
        get
        {
            return value;
        }

        set
        {
            if (value > 1)
            {
                this.value = 1;
            }
            else if (value < 0)
            {
                this.value = 0;
            }
            else
            {
                this.value = value;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
       // transform.parent.GetChild(1).GetComponent<Text>().text = control.mainPlayer.HP.ToString();
      //  Value = ExchangeValue(control.mainPlayer.HP, control.mainPlayer.HPMax, 0);


    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Image>().fillAmount = Mathf.Lerp(GetComponent<Image>().fillAmount, Value, Time.deltaTime * 5);
      //  transform.parent.GetChild(1).GetComponent<Text>().text = System.Math.Round(GetComponent<Image>().fillAmount * control.mainPlayer.HPMax).ToString();

    }

    public static float ExchangeValue(float val, float maxVal, float minVal)
    {
        return ((val - minVal) / (maxVal - minVal));


    }
}
