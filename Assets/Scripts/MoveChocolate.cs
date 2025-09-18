using UnityEngine;

public class MoveChocolate : MonoBehaviour
{

    public float speed = 0.0f;

    private Vector3 originalPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //the spawn point
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void reuse()
    {
        speed = 0;

        //neutralize transformation
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;

        //neutralize physics
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

    }
}
