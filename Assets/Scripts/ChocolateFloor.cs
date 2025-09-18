using UnityEngine;

public class ChocolateFloor : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "chocolate")
        {
            Transform choc = other.transform;
            MoveChocolate move = choc.GetComponent<MoveChocolate>();

            move.reuse();

        }
    }
}
