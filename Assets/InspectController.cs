using UnityEngine;
using System.Collections;

public class InspectController : MonoBehaviour {
	public 	string 					description;
	public 	bool					inspectionEnabled;
	private	GameObject				text = null;
	public GameObject				prefab;

	void Awake() {

	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (renderer.isVisible && inspectionEnabled) {
			GameObject camera = GameObject.Find ("Main Camera");
			float distance = Vector3.Distance (camera.GetComponent<Transform> ().position, transform.position);
			if (distance >= 30) {
				DestroyText();
				return;
			}
			if( text == null ) {
				CreateText ();
			}
		} else {
			DestroyText();
		}
	}

	void CreateText() {
		Vector3 v = transform.position;
		v.y += 0.5f;
		text = (GameObject) Instantiate(prefab, v, transform.rotation );
		text.transform.localScale = new Vector3(-0.1f,0.1f,0.1f);
		text.GetComponent<InspectableTextController>().SetText(description);
	}

	void DestroyText() {
		if (text != null) {
			Destroy(text);
			text = null;
		}
	}

	void OnDestroy() {
		DestroyText ();
	}

}
