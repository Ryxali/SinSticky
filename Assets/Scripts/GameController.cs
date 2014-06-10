using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	private GameObject tongueEnd;
	public Transform tongueSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) 
		{
			Instantiate(tongueEnd, tongueSpawn.position, tongueSpawn.rotation);
		}
		if (Input.GetButtonUp ("Fire1"))
		{
			Destroy(GameObject.FindWithTag("Tongue"));
		}
	}
}
