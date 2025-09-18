using UnityEngine;

public class ChocActivate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "chocolate")
        {
            Transform choc =other.transform;

            Rigidbody body = choc.GetComponent<Rigidbody>();

            body.isKinematic = true;

            MoveChocolate move = choc.GetComponent<MoveChocolate>();
            move.speed = 1.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "chocolate")
        {
            Transform choc = other.transform;

            Rigidbody body = choc.GetComponent<Rigidbody>();
            body.isKinematic = false;

            MoveChocolate move = choc.GetComponent<MoveChocolate>();
            move.speed = 0.0f;

        }
    }


}
