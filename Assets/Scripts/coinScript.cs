using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public float rotationSpeed;
    private int mode;
    private float time;
    void Awake()
    {
        time = 0.0f;
        mode = 0;
        transform.rotation = Quaternion.Euler(90, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        if (mode == 1) {
            time += Time.deltaTime;
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime * 100 * (0.8f-time));
            transform.position += new Vector3(0, 0.001f, 0)*10* (0.8f - time);
        }
    }

    void carCollision() {
        mode = 1;
        Destroy(gameObject,0.8f);
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
        time += Time.deltaTime;
    }
}
