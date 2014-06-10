using UnityEngine;
using System.Collections;

public class InspectableTextController : MonoBehaviour {
	private Transform activeCameraTransform;

	// Use this for initialization
	void Start () {
		activeCameraTransform = GameObject.Find ("Hookshot Camera").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (activeCameraTransform);
	}

	public void SetText(string text) {
		gameObject.GetComponent<TextMesh> ().text = text;
	}
}
