using UnityEngine;

public class DropChocolate : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "hand")
        {
            Transform trs = other.transform;            

            MoveHand hand =  trs.GetComponent<MoveHand>();

            hand.ReturnStartPos();

            //if i have chocolate
            if(trs.childCount > 0)
            {
                Transform choc = trs.GetChild(0);
                choc.GetComponent<Rigidbody>().isKinematic = false;
                choc.parent = null;

            }



        }
    }
}
