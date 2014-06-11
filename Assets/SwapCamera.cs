using UnityEngine;
using System.Collections;

public class SwapCamera : MonoBehaviour {
	public Camera firstPersonCamera;
	public Camera thirdPersonCamera;
	public Camera hookshotCamera;
	public GameObject body;
	private bool inHookshotMode = false;
	private TongueController controller;
	private GameObject gun;
	private GameObject plunger;
	private GameObject line;
	// Use this for initialization
	void Start () {
		firstPersonCamera.enabled = true;
		body.renderer.enabled = false;
		thirdPersonCamera.enabled = false;
		controller = GameObject.Find ("TongueEnd").GetComponent<TongueController> ();
		gun = GameObject.Find ("Gun");
		plunger = GameObject.Find ("Plunger");
		line = GameObject.Find ("Line");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		TongueController.Stage stage = controller.getStage ();
		switch (stage) {
		case TongueController.Stage.standby:
			body.renderer.enabled = false;
			thirdPersonCamera.enabled = false;
			hookshotCamera.enabled = false;
			firstPersonCamera.enabled = true;
			gun.renderer.enabled = false;
			plunger.renderer.enabled = false;
			line.renderer.enabled = false;
			break;
		case TongueController.Stage.shooting:
			firstPersonCamera.enabled = false;
			thirdPersonCamera.enabled = false;
			body.renderer.enabled = false;
			hookshotCamera.enabled = true;
			gun.renderer.enabled = true;
			plunger.renderer.enabled = true;
			line.renderer.enabled = true;
			break;
		case TongueController.Stage.reeling:
			firstPersonCamera.enabled = false;
			hookshotCamera.enabled = false;
			thirdPersonCamera.enabled = true;
			body.renderer.enabled = true;
			gun.renderer.enabled = true;
			plunger.renderer.enabled = true;
			line.renderer.enabled = true;
			break;
		}
	}
}
