﻿using UnityEngine;
using System.Collections;

public class TonguedMove : MonoBehaviour {

	public float flyspeed;
	public float stopDistance;
	public GameObject tongueEnd;
	public GameObject dragObject;

	// Use this for initialization
	void Start () {
		if (dragObject == null) {
			dragObject = gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		bool tongueStop = tongueEnd.GetComponent<TongueController>().getStop();

		if (tongueStop)
		{
			float distance = Vector3.Distance(tongueEnd.transform.position, rigidbody.position);
			Vector3 direction = Vector3.Normalize(tongueEnd.transform.position - rigidbody.position);
			Vector3 newVelocity = direction * flyspeed;

			if (distance > stopDistance)
				rigidbody.AddForce(newVelocity);

			/*if (distance > stopDistance)
			{
				//if (Vector3.Distance(Vector3.Normalize(rigidbody.velocity) + rigidbody.position, tongueEnd.transform.position) <= distance)
				if (Vector3.Distance(Vector3.Normalize(rigidbody.velocity), Vector3.Normalize(direction)) < 1.57f)
				{
					rigidbody.velocity = newVelocity;
				}
				else
				{
					Vector3 temp = rigidbody.velocity;
					temp.x = -temp.x;
					temp.z = -temp.z;
					temp.y = 0;
					rigidbody.velocity = temp;
				}
			}*/
		}
	}
}