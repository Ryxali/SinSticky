using UnityEngine;
using System.Collections;

public class worldPosition : MonoBehaviour {
	public Transform root_pos;
	public Transform middle_spine_pos;
	public Transform upper_spine_pos;
	public Transform R_arm_pos;
	public Transform R_elbow_pos;
	public Transform R_wrist_pos;
	public Transform R_hand_pos;
	// Use this for initialization
	void Start () {
	
	}

	public Vector3 GetPosition() {
		return root_pos.position +
			middle_spine_pos.position +
			upper_spine_pos.position +
			R_arm_pos.position +
			R_elbow_pos.position +
			R_wrist_pos.position +
			R_hand_pos.position;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
