using UnityEngine;
using System.Collections;

public class CoffeeScript : MonoBehaviour {
	private static WinController winController = null;

	void Awake() {
		if (!winController) {
			GameObject obj	= GameObject.Find("WinHandler");
			winController	= obj.GetComponent<WinController>();
		}
	}

	// Use this for initialization
	void Start () {
		winController.AddCoffee ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag != "Player")
			return;
		winController.SubCoffee ();
		Destroy (gameObject);
	}
}
