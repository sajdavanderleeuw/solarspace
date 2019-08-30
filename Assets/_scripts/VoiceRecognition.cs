using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecognition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeColor()
    {

        this.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}
