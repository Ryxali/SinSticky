﻿using UnityEngine;
using System.Collections;

public class TongueController : MonoBehaviour {
	public GameObject cam;
	public GameObject tongueSpawn;
	public float force;

	public enum Stage
	{
		shooting,
		reeling,
		standby
	};

	Stage stage;

	private bool stop;
	private bool alive;
	// Use this for initialization
	void Start () {
		//camera = GameObject.FindWithTag ("MainCamera");
		//rigidbody.AddForce (camera.transform.forward * force);
		die ();
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (stage);


		if (Input.GetButtonDown ("Fire1")) {
			live ();
		} 

		else if (Input.GetButtonUp ("Fire1")) 
		{
			die ();
		}

		if (!alive) 
		{
			rigidbody.position = tongueSpawn.transform.position;
		}

		if (stop) 
		{
			rigidbody.Sleep ();
		}
	}

	void OnCollisionEnter()
	{
		stop = true;
		stage = Stage.reeling;
	}

	public bool getStop()
	{
		return stop;
	}

	void live()
	{
		collider.enabled = true;
		//renderer.enabled = true;
		rigidbody.AddForce (cam.transform.forward * force);
		alive = true;
		stage = Stage.shooting;
	}

	void die()
	{
		collider.enabled = false;
		//renderer.enabled = false;
		stop = false;
		alive = false;
		stage = Stage.standby;
	}

	public Stage getStage()
	{
		return stage;
	}
}
