using UnityEngine;
using System.Collections;

public class PoliceController : MonoBehaviour {
	public Rigidbody[] rigidBodies;
	private bool ragdolled;
	// Use this for initialization
	void Start () {
		ragdolled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && ragdolled == false)
		{
			Debug.Log("Player-Police collision");
			Animator animator = GetComponent<Animator> ();
			animator.enabled = false;
			foreach (Rigidbody body in rigidBodies)
			{
				body.isKinematic = false;
				Debug.Log("Blubb");
			}
			ragdolled = true;
		}
	}
}
