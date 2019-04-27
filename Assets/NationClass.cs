using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationClass : MonoBehaviour
{
    public Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Ani.SetBool("SizeInOut", true);
    }
    private void OnMouseExit()
    {
        Ani.SetBool("SizeInOut", false);

    }
}
