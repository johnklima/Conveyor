using UnityEngine;


public class ConveyorClick : MonoBehaviour
{

    public Transform lefthand;
    public Transform righthand;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Transform hand = null;

        if (Input.GetMouseButtonDown(0))
        {
            hand = lefthand;
            TryPickup(hand);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            hand = righthand;
            TryPickup(hand);
        }
    }

    void TryPickup(Transform _hand )
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int mask = 1 << 9; //assigned 9 as the pickables

        RaycastHit hit;
        
        Transform trs;       //the thing I hit

        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            trs = hit.collider.transform;

            Debug.Log("mouse hit " + trs.name);

            _hand.GetComponent<MoveHand>().MoveToEndPos(hit.point);
           
        }
    }
}
