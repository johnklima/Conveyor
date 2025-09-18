using UnityEngine;

public class ChocActivate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "chocolate")
        {
            Transform choc = collision.collider.transform;

            //check if in hand, do nothing
            if (choc.GetComponent<MoveChocolate>().inHand)
                return;

           
            MoveChocolate move = choc.GetComponent<MoveChocolate>();
            Rigidbody body = choc.GetComponent<Rigidbody>();
            body.isKinematic = true;
            move.speed = 2f;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "chocolate")
        {
            Transform choc = collision.collider.transform;

            //check if in hand, do nothing
            if (choc.GetComponent<MoveChocolate>().inHand)
                return;

            Rigidbody body = choc.GetComponent<Rigidbody>();
            body.isKinematic = false;

        }
    }
}
