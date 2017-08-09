using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sub Bass = 20 - 60 Hz
 * Bass     = 60 - 250 Hz
 * Low Midrange = 250 - 500 Hz
 * Midrange = 500 - 2k Hz
 * Upper Midrange = 2k - 4k Hz
 * Presence  = 4k - 6k Hz
 * Brilliance = 6k - 20k Hz
*/

[RequireComponent(typeof(AudioSource))]
public class AudioVisual : MonoBehaviour {

    AudioSource _audio;
    public float[] specturm = new float[512];
    public float test = 10;


	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        GetAudioSpecturm();

    }

    public void GetAudioSpecturm()
    {
        _audio.GetSpectrumData(specturm, 0, FFTWindow.Blackman);
    }

}
