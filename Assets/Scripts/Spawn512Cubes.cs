using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn512Cubes : MonoBehaviour {

    public GameObject audioSource;
    AudioVisual _audioVisual;

    //Main Variables
    public float radius;
    public int objectNumber;
    private int count;
    private float angle = 0;
    private float slice;

    public float spectrumHeight = 0;

    private float xPos;
    private float yPos;


    public GameObject radialObj;
    List<GameObject> RadialObjs = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        _audioVisual = audioSource.GetComponent<AudioVisual>();


        Vector3 centerPoint = this.gameObject.transform.position;
        count = _audioVisual.specturm.Length;
        slice = Mathf.PI * 2 / count;

        //Instatiate Objects
        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate(radialObj, gameObject.transform.position, Quaternion.identity) as GameObject;
            RadialObjs.Add(temp);
            temp.transform.SetParent(this.gameObject.transform);
        }

        //Place Cubes in Circle and rotate towards center
        for (int i = 0; i < count; i++)
        {
            angle = i * slice;

            xPos = centerPoint.x + Mathf.Cos(angle) * radius;
            yPos = centerPoint.y + Mathf.Sin(angle) * radius;

            Vector3 placeObj = new Vector3(xPos, yPos, centerPoint.z);
            Vector3 rotateObj = new Vector3(0, 0, angle * 180 / Mathf.PI);

            RadialObjs[i].transform.position = placeObj;
            RadialObjs[i].transform.eulerAngles = rotateObj;
        }

        //Rotate GameObject
        this.transform.Rotate(90, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < count; i++)
        {
            RadialObjs[i].transform.localScale = new Vector3(1, 1, _audioVisual.specturm[i] * spectrumHeight + 1);
        }
    }


    float SinIt(float _f, float _a, float _s)
    {
        _f = _a * Mathf.Sin(Time.time) * _s + _f;
        return _f;
    }
}
