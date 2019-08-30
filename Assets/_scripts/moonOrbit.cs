using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonOrbit : MonoBehaviour {

    public GameObject Earth_2K;//earth the moon will orbit around
    public float speed; // speed of orbit
	// Use this for initialization
	void Start () {
        Debug.Log("MoonOrbit is starting");
    }
	
	// Update is called once per frame
	void Update ()
    {
        OrbitAround (); //this  will make moon orbit around the earth
	}

    void OrbitAround()
    {
        transform.RotateAround(Earth_2K.transform.position, Vector3.down, speed * Time.deltaTime); // makes moon orbit around earth
    }

}
