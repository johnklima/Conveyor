using UnityEngine;


public class MoveChocolate : MonoBehaviour
{
    public float speed = 0.0f;
    public bool inHand = false;

    private Vector3 originalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn point
        originalPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void reuse()
    {
        //reset
        speed = 0;
        inHand = false;

        //neutralize transformation
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;
        
        //neutralize physics
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "hand" && !inHand)
        {
            Transform hand = collision.collider.transform;
            Grab(hand);

            hand.GetComponent<MoveHand>().ReturnStartPos();

        }
    }

    public void Grab(Transform hand)
    {       
                
        transform.parent = hand;
        speed = 0;
        inHand = true;
        transform.localPosition = Vector3.zero;  //make sure it is in hand at zero

        Rigidbody body = transform.GetComponent<Rigidbody>();
        body.isKinematic = true;


    }
}
