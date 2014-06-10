using UnityEngine;
using System.Collections;

public class SwapCamera : MonoBehaviour {
	public Camera firstPersonCamera;
	public Camera thirdPersonCamera;
	public Camera hookshotCamera;
	private bool inHookshotMode = false;
	private TongueController controller;
	// Use this for initialization
	void Start () {
		firstPersonCamera.enabled = true;
		renderer.enabled = false;
		thirdPersonCamera.enabled = false;
		controller = GameObject.Find ("TongueEnd").GetComponent<TongueController> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		TongueController.Stage stage = controller.getStage ();
		if (Input.GetButtonDown ("Fire1")) {
			inHookshotMode = true;
		}
		switch (stage) {
		case TongueController.Stage.standby:
			renderer.enabled = false;
			thirdPersonCamera.enabled = false;
			hookshotCamera.enabled = false;
			firstPersonCamera.enabled = true;
			break;
		case TongueController.Stage.shooting:
			firstPersonCamera.enabled = false;
			thirdPersonCamera.enabled = false;
			renderer.enabled = false;
			hookshotCamera.enabled = true;
			break;
		case TongueController.Stage.reeling:
			firstPersonCamera.enabled = false;
			hookshotCamera.enabled = false;
			thirdPersonCamera.enabled = true;
			renderer.enabled = true;
			break;
		}
	}
}
