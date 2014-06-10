using UnityEngine;
using System.Collections;

public class WiggleMovement : MonoBehaviour {
	public float force = 100;
	public float upForce = 100;
	public float torqueForce = 60;
	public Camera cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire2")) {
			rigidbody.AddForce (cam.transform.forward * force + Vector3.up*upForce);
			rigidbody.AddTorque (cam.transform.right*torqueForce);
		}
	}
}
