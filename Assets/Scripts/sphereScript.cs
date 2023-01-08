using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class sphereScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Vector3 direction;
    // Start is called before the first frame update
    void Awake()
    {
        direction = new Vector3(1, 0, 0);
        rb = GetComponent<Rigidbody>();
    }

    public void setTarget(Vector3 t) {
        
        Vector3 move = t - transform.position;
        move.y = 0;
        rb.AddForce(move.normalized * speed); 
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.01) direction = rb.velocity;
        //due to AR innacuracies, some frames the car moves up and down because of the plane moving, this makes the car face up or down instead of being parallell to the plane so we set y to 0
        direction.y = 0;
        transform.LookAt(transform.position + direction);
        transform.RotateAround(transform.position, Vector3.up, -90);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("carCollision", SendMessageOptions.DontRequireReceiver);
    }
}
