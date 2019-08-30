using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using HoloToolkit;
using System.Linq;

public class TapHandler : MonoBehaviour {

    private GestureRecognizer recogniser;
    private GameObject FocusedObject;
    private Color OldColour;

    public TextToSpeechOutput TextToSpeechObj;

    // Use this for initialization
    void Start () {

        recogniser = new GestureRecognizer();
        recogniser.SetRecognizableGestures(GestureSettings.Tap);
        recogniser.Tapped += onTapped;
        recogniser.StartCapturingGestures();

    }

    // Update is called once per frame
    void Update () {
		
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

            if (FocusedObject.name == this.transform.gameObject.name)
            {
                Debug.Log("object tapped: " + FocusedObject.name);

            }

            if (FocusedObject.name == "Question3DText")
            {
                Debug.Log("3D Text with the question has been tapped");
                //SceneManager.LoadScene("myscenename", LoadSceneMode.Additive);
            }


        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

    }
}

