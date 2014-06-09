using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour {
	public Transform target;
	public double distance = 10.0;
	
	public double xSpeed = 250.0;
	public double ySpeed = 120.0;
	
	public double yMinLimit = -20;
	public double yMaxLimit = 80;

	public float offsetY = 0.0f;

	private double x = 0.0;
	private double y = 0.0;
	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	double clamp(double x, double min, double max) {
		if (x < min)
			return min;
		if (x > max)
			return max;
		return x;
	}

	void LateUpdate() {
		if (target) {
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
			
			y = clamp(y, yMinLimit, yMaxLimit);
			if(Input.GetAxis("Mouse ScrollWheel") < 0) {
				distance += 1;
			}
			else if (Input.GetAxis("Mouse ScrollWheel") > 0) {
				distance -= 1;
			}
			Quaternion rotation = Quaternion.Euler((float)y, (float)x, 0.0f);
			Vector3 position = rotation * new Vector3(0.0f, 0.0f, (float)-distance) + target.position + target.up*offsetY;

			transform.rotation = rotation;
			transform.position = position;
		}
	}
}
