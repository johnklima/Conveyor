using UnityEngine;

public class ChocolateFloor : MonoBehaviour
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
        //reuse this chocolate
        if (collision.collider.tag == "chocolate")
        {
            Transform choc = collision.collider.transform;

            Debug.Log(choc.name + "splat");

            MoveChocolate move = choc.GetComponent<MoveChocolate>();
            move.reuse();

        }
    }

}
