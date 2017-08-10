using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

	public float rotateSpeed;
	
	// Update is called once per frame
	void Update () {

		//Rotate camera at a steady, steady, pace...
		transform.Rotate( new Vector3(0, rotateSpeed, 0));

	}
}
