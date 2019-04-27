using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFullBody : MonoBehaviour
{
    

    public Vector2 StartPos;
    Vector2 StartPos2;

    public Vector2 EndPos;
    Vector2 EndPos2;


    public bool MovingHorizon;
    public float Total;
    public float TimeCount;
     
    
    // Start is called before the first frame update
    void Start()
    {
        StartPos2 = StartPos;
        EndPos2 = EndPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingHorizon)
        {
            TimeCount += Time.deltaTime;
            transform.localPosition = Vector2.Lerp(StartPos2, EndPos2, TimeCount / Total);
        }


        if (Input.GetKeyDown("a"))
        {
            MoveIn();
        }
    }

    public void MoveIn()
    {
        TimeCount = 0;
        transform.localPosition = StartPos;
        MovingHorizon = true;
    }
}
