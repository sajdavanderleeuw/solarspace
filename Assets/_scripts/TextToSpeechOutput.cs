using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class TextToSpeechOutput : MonoBehaviour {

    private TextToSpeech tts;
    public string TextToSpeak;
    public AudioSource SpeakerAstronaut;
    public AudioSource Speaker3DText;
    
    // Use this for initialization
    void Start()
    {
        tts = GetComponent<TextToSpeech>();
        tts.Voice = TextToSpeechVoice.Mark;
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void GiantStepQuestion()
    {
        tts.AudioSource = Speaker3DText;
        tts.StartSpeaking(TextToSpeak);
    }
    
}