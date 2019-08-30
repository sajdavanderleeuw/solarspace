using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class TextToSpeechOutput : MonoBehaviour {

    private TextToSpeech tts;
    public string TextToSpeak;
    public AudioSource SpeakerAstronaut;
    
    // Use this for initialization
    void Start()
    {
        tts = GameObject.Find("Audio Manager").GetComponent<TextToSpeech>();
        tts.AudioSource = GameObject.Find("Astronaut").GetComponent<AudioSource>();
        tts.Voice = TextToSpeechVoice.Mark;

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void PoseLeapQuestion()
    {
        tts.StartSpeaking(TextToSpeak);
    }
    
}