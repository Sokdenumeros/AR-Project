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
    private GameObject newObject;
    private ARRaycastManager RCmngr;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    private void Awake()
    {
        RCmngr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(t.position);
                RaycastHit hitobject;
                if (Physics.Raycast(ray, out hitobject)) physicsHitAction(hitobject.transform.gameObject);
                else if (RCmngr.Raycast(t.position, hits, TrackableType.PlaneWithinPolygon)) arHitAction();
            }
        }
    }

    private void physicsHitAction(GameObject o) {
        Destroy(o,2);
    }

    private void arHitAction()
    {
        Instantiate(objectToCreate, hits[0].pose.position, hits[0].pose.rotation);
    }
}