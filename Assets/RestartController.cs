using UnityEngine;
using System.Collections;

public class RestartController : MonoBehaviour {
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}
}
