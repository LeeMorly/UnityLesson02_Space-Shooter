using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomROatator : MonoBehaviour {
	public float tumble;
	void Start () {
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere*tumble; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
