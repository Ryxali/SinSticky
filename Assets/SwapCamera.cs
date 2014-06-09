using UnityEngine;
using System.Collections;

public class SwapCamera : MonoBehaviour {


	public Camera firstPersonCamera;
	public Camera thirdPersonCamera;

	// Use this for initialization
	void Start () {
		firstPersonCamera.enabled = true;
		renderer.enabled = false;
		thirdPersonCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C)) {
			firstPersonCamera.enabled = !firstPersonCamera.enabled;
			renderer.enabled = !renderer.enabled;
			thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
		}
	}
}
