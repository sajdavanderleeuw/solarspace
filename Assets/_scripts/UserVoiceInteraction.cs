using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserVoiceInteraction : MonoBehaviour {

    public AudioClip armstrong0;
    public AudioClip armstrong1;
    public AudioSource armstrongSource;
    public int currentStep;

    public TextToSpeechOutput ttsOutput;

    // Use this for initialization
    void Start () {
        currentStep = 0;
        ttsOutput.GiantStepQuestion();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UserSaysYes()
    {
        Debug.Log("UserSaysYes called");
        PlayAudioForCurrentStep();
    }

    private void PlayAudioForCurrentStep()
    {
        if (currentStep == 0)
        {
            armstrongSource.clip = armstrong0;
            armstrongSource.Play();

        } else if (currentStep == 1)
        {
            armstrongSource.clip = armstrong1;
            armstrongSource.Play();
        }
        currentStep++;
    }


}
