using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireDelta;
	private float nextFire=0.5f;
	private float myTime=0.0f;



	private void Update()
	{
		myTime+=Time.deltaTime;

		if (Input.GetButtonDown("Fire1") /*&& myTime>nextFire*/) {

			//nextFire = Time.time + fireDelta;

			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			//myTime = 0;
		}

	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Rigidbody rbody= gameObject.GetComponent<Rigidbody> () ;

		rbody.velocity= movement*speed;

		rbody.position = new Vector3 (
			Mathf.Clamp (rbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rbody.position.z, boundary.zMin, boundary.zMax)
		);
		rbody.rotation = Quaternion.Euler (0.0f, 0.0f, rbody.velocity.x*-tilt);	

	}


}
