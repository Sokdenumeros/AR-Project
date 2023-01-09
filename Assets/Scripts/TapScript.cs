using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class TapScript : MonoBehaviour
{
    public GameObject objectToCreate;
    public GameObject coin;
    public Camera arCamera;
    private GameObject car;
    private int mode;
    public static int score;
    Text scoreText;
    //private ARRaycastManager RCmngr;
    //static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    private void Awake()
    {
        mode = 0;
        //RCmngr = GetComponent<ARRaycastManager>();
    }
    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //by multiplying i by Input.touchCount or not we can make the loop only process the first touch or all of them.
        for (int i = 0; i * Input.touchCount < Input.touchCount; ++i)
        {
            Touch t = Input.GetTouch(i);
            if (mode == 0 && t.phase == TouchPhase.Began && t.position.x < 300 && t.position.y < 300) mode = -1;
            if (mode == -1)
            {
                if (t.phase == TouchPhase.Ended) mode = 1;
                return;
            }
            Ray ray = arCamera.ScreenPointToRay(t.position);
            RaycastHit hitobject;

            if (Physics.Raycast(ray, out hitobject))
            {
                if (mode == 0) carInteraction(hitobject);
                else if (mode == 1 && t.phase == TouchPhase.Ended)
                {
                    Instantiate(coin, hitobject.point + new Vector3(0, 0.1f, 0), Quaternion.Euler(0, 0, 0));
                    mode = 0;
                }
            }
        }
        scoreText.text = "Score:	 " + score;
    }

    private void carInteraction(RaycastHit o)
    {
        //o.transform.gameObject;
        if (car == null) car = Instantiate(objectToCreate, o.point, Quaternion.Euler(0, 0, 0));
        else car.SendMessage("setTarget", o.point + new Vector3(0, 0.2f, 0), SendMessageOptions.DontRequireReceiver);
    }

    /*
    private void arHitAction()
    {
        if(car == null) car = Instantiate(objectToCreate, hits[0].pose.position, hits[0].pose.rotation);
        else car.SendMessage("setTarget", hits[0].pose.position, SendMessageOptions.DontRequireReceiver);
    }*/
}