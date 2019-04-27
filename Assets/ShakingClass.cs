using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingClass : MonoBehaviour
{
    public float Amount;
    public bool shaking;
    Vector2 OriginPos;

    // Start is called before the first frame update
    void Start()
    {
        OriginPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking== true)
        {
            Vector2 NewPos = OriginPos + Random.insideUnitCircle * (Amount * Time.deltaTime);
            transform.position = NewPos;
        }
    }
    public void ShakeMe(float amt)
    {
        StartCoroutine(ForShakeMe(amt));
    }

    IEnumerator ForShakeMe(float amt)
    {
        if (shaking == false)
        {
            Amount = amt;
            shaking = true;
            yield return new WaitForSeconds(1);
            shaking = false;
            transform.position = OriginPos;
        }
              
    }
}
