using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using HoloToolkit;
using System.Linq;


public class WindowOnTap : MonoBehaviour
{

    private GestureRecognizer recogniser;
    private GameObject FocusedObject;
    private Color OldColour;


    public BreakableWindow script;
        
      


    void Start()
    {
      
        recogniser = new GestureRecognizer();
        recogniser.SetRecognizableGestures(GestureSettings.Tap);
        recogniser.Tapped += onTapped;
        recogniser.StartCapturingGestures();

    }

    // Update is called once per frame
    void Update()
    {

   



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
            Debug.Log("onTapped hit gameobject with name '" + FocusedObject.name+"'");

            if (FocusedObject.name == this.transform.gameObject.name)
            {
                Debug.Log("calling breakWindow(), as we hit '" + FocusedObject.name+"'");
                if (!script.isBroken) script.breakWindow();
            }

        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

    }

    private void OnDestroy()
    {
        recogniser.Tapped -= onTapped;
        recogniser.StopCapturingGestures();
    }

}