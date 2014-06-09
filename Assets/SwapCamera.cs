using UnityEngine;
using System.Collections;

public class SwapCamera : MonoBehaviour {
	public GameObject tongue;
	public Camera firstPersonCamera;
	public Camera thirdPersonCamera;
	public Camera hookshotCamera;
	private bool inHookshotMode = false;
	// Use this for initialization
	void Start () {
		firstPersonCamera.enabled = true;
		renderer.enabled = false;
		thirdPersonCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			inHookshotMode = true;
		}
		if (tongue.GetComponent<TongueController> ().getStop ()) {
			firstPersonCamera.enabled = false;
			thirdPersonCamera.enabled = false;
			hookshotCamera.enabled = true;
			/*bool tongueStop = tongue.GetComponent<TongueController> ().getStop ();
			if(tongueStop) {

			}
			else
			{
				renderer.enabled = true;
				firstPersonCamera.enabled = false;
				hookshotCamera.enabled = false;
				thirdPersonCamera.enabled = true;
			}*/

		} else {
			renderer.enabled = false;
			thirdPersonCamera.enabled = false;
			hookshotCamera.enabled = false;
			firstPersonCamera.enabled = true;
		}
	}
}
