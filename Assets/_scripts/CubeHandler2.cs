using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using HoloToolkit;
using System.Linq;


public class CubeHandler2 : MonoBehaviour
{

    private GestureRecognizer recogniser;
    private GameObject FocusedObject;
    private Color OldColour;
    public bool rotateMe = false;
    public bool placeMe = false;
 



   public void grow()
    {

       this.transform.localScale += new Vector3(0.1f,0,0);

    }

   // Use this for initialization
    void Start()
    {

        recogniser = new GestureRecognizer();
        recogniser.SetRecognizableGestures(GestureSettings.Tap);
        recogniser.Tapped += onTapped;
        recogniser.StartCapturingGestures();
        Debug.Log("regisrred");
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateMe)
        {
            this.transform.Rotate(0.0f, 0.75f, 0.0f, Space.World);
        }
        if(placeMe)
        {
            //this.transform.Translate(Vector3.left * 0.1f, Space.World);
        }

     

    }

    public void onTapped(TappedEventArgs args)
    {

        var headPosition = args.headPose.position;
        var gazeDirection = args.headPose.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 10.0f, Physics.DefaultRaycastLayers))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
            Debug.Log("onTapped");


            if (FocusedObject.name == this.transform.gameObject.name)
            {
                Debug.Log("is my parent " + this.transform.gameObject.name);
                this.transform.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                rotateMe = ! rotateMe;
                placeMe = !placeMe;
              
            }

            //FocusedObject.transform.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

    }
}
