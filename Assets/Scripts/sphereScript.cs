using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount%100 > 50)
            transform.position += Vector3.up * Time.deltaTime;
        else
            transform.position -= Vector3.up * Time.deltaTime;
    }
}
