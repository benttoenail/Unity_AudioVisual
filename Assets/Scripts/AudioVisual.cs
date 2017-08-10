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
	public static float[] specturm = new float[512];
	public static float[] freqBands = new float[8];


	// Use this for initialization
	void Start () 
	{
		
        _audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () 
	{

        GetAudioSpecturm();
		MakeFrequencyBands();
    }

    public void GetAudioSpecturm()
    {
		
        _audio.GetSpectrumData(specturm, 0, FFTWindow.Blackman);

    }


	void MakeFrequencyBands()
	{
		
		int count = 0;

		for(int i = 0; i < 8; i++)
		{
			int sampleCount = (int)Mathf.Pow(2, i) * 2;
			float average = 0;

			if( i == 7 ){
				sampleCount += 2;
			}


			for(int j = 0; j < sampleCount; j++)
			{
				average += specturm[count] * (count + 1);
				count++;
			}

			average /= count;

			freqBands[i] = average;

		}
	}

}
