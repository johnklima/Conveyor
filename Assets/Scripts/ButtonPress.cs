using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    bool press = false;
    float cycle = 0;
    Vector3 initPos;

    public float ypos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(press)
        {
            cycle += Time.deltaTime * 4;
            ypos = -Mathf.Sin(cycle) * 0.25f;
            

            if(ypos >= 0.23f)
            {
                press = false;
                cycle = 0;
                return;
            }

            Vector3 pos = initPos;
            pos.y += ypos;

            transform.localPosition = pos;

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.tag == "hand")
        {
            
            Transform trs = other.transform;
            trs.GetComponent<MoveHand>().ReturnStartPos();

            Transform choc = null;

            if(trs.childCount > 0)
                choc = trs.GetChild(0);

            if (choc)
            {
                choc.GetComponent<Rigidbody>().isKinematic = false;
                choc.parent = null;

                Debug.Log("RUINED THE CHOCOLATE!!");
                return;
            }
            else
            {
                Debug.Log("BIN EMPTY");
                press = true;
            }

        }


    }
}
