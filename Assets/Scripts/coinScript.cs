using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public float rotationSpeed;

    void Awake()
    {
        transform.rotation = Quaternion.Euler(90, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void carCollision() {
        Destroy(gameObject);
    }
}
