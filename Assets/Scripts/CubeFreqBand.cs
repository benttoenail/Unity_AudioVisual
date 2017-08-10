using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFreqBand : MonoBehaviour {

	public int bandwith;
	public float mult;
	public float startHeight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(transform.localScale.x, (AudioVisual.freqBands[bandwith]*mult) + startHeight, transform.localScale.z);

		print(AudioVisual.freqBands[3]);
	}
}
