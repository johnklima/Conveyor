using UnityEngine;

public class MoveHand : MonoBehaviour
{

    private Vector3 startpos;   //the home position
    private Vector3 endpos;     //the click target position

    //do it?
    private bool moveto = false;
    private bool returnto = false;

    //the T accumulation of time for move type
    private float Tmoveto = -1;
    private float Treturn = -1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get our home position
        startpos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveto)
        {
            Tmoveto += Time.deltaTime * 4.0f;
            if(Tmoveto >= 1.0f)
            {
                Tmoveto = 1.0f;
                moveto = false;
            }
            
            transform.position = Vector3.Slerp(startpos, endpos, Tmoveto);
        }

        if (returnto)
        {
            Treturn += Time.deltaTime * 4.0f;
            if (Treturn >= 1.0f)
            {
                Treturn = 1.0f;
                returnto = false;
            }

            transform.position = Vector3.Slerp(endpos, startpos, Treturn);
        }

    }

    public void ReturnStartPos()
    {
        endpos = transform.position;
        Treturn = 0;
        returnto = true;
        
    }

    public void MoveToEndPos(Vector3 _endpos)
    {
        endpos = _endpos;
        Tmoveto = 0;
        moveto = true;
    }
}
