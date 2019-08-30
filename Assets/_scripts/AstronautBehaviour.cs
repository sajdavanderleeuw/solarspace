using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using HoloToolkit;
using System.Linq;


public class AstronautBehaviour : MonoBehaviour {

    public AudioTrigger myAudioManager;
    private GestureRecognizer recogniser;
    private GameObject FocusedObject;
    public GameObject QuestionText;

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

    public void OnTriggerEnter(Collider other)
    {
        myAudioManager.OnTriggerAstronautPlay();
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
                Debug.Log("you tapped the '" + FocusedObject.name + "'");
                myAudioManager.PlayAudioLadder();
            } else if (FocusedObject.name == "Earth")
            {
                Debug.Log("You tapped earth");
                GameObject QuestionTextInstance = Instantiate(QuestionText, GameObject.Find("Earth").transform);
            } else if (FocusedObject.name =="Moon")
            {
                Debug.Log("You tapped moon");
            }

        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

    }

}
