using UnityEngine;
using System.Collections;

public class TextRotator : MonoBehaviour {

	public Camera cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (cam.transform);
	}
}
