using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapScript : MonoBehaviour
{
    public GameObject objectToCreate;
    public Camera arCamera;
    private GameObject car;
    //private ARRaycastManager RCmngr;
    //static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    private void Awake()
    {
        //RCmngr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //by multiplying i by Input.touchCount or not we can make the loop only process the first touch or all of them.
        for (int i = 0; i*Input.touchCount < Input.touchCount; ++i)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began || true)
            {
                Ray ray = arCamera.ScreenPointToRay(t.position);
                RaycastHit hitobject;
                if (Physics.Raycast(ray, out hitobject)) physicsHitAction(hitobject);
                //Physics raycast seems to interact with AR planes, but in case it was needed, here is how to do it with an ARraycast
                //if (RCmngr.Raycast(t.position, hits, TrackableType.PlaneWithinPolygon)) arHitAction();
            }
        }
    }

    private void physicsHitAction(RaycastHit o) {
        //o.transform.gameObject;
        if (car == null) car = Instantiate(objectToCreate, o.point, Quaternion.Euler(0,0,0));
        else car.SendMessage("setTarget", o.point + new Vector3(0,0.2f,0), SendMessageOptions.DontRequireReceiver);
    }

    /*
    private void arHitAction()
    {
        if(car == null) car = Instantiate(objectToCreate, hits[0].pose.position, hits[0].pose.rotation);
        else car.SendMessage("setTarget", hits[0].pose.position, SendMessageOptions.DontRequireReceiver);
    }*/
}