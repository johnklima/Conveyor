using UnityEngine;

public class ButtonClick : MonoBehaviour
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
            TryButtonClick(hand);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            hand = righthand;
            TryButtonClick(hand);
        }
    }

    void TryButtonClick(Transform _hand)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int mask = 1 << 7; //assigned 7 as the button

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
