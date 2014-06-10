using UnityEngine;
using System.Collections;

public class HookChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TongueController c = GameObject.Find ("TongueEnd").GetComponent<TongueController>();
		print (c.getStage ().ToString());
	}
}
