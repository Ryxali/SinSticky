using UnityEngine;
using System.Collections;

public class ValdgunController : MonoBehaviour {
	
	public float waitTime;
	public float speed;
	public float rotationSpeed;

	private Animator animator;
	private int indexCounter;
	private float nextMove;
	private Vector3 nextPosition;

	private float forcePushTimer;
	private bool forcePushBool;
	public float pushForce;
	public float pushWaitTime;

	private bool walk;

	//private Transform targetRotationTransform;

	private Vector3 targetDirection;

	[SerializeField]
	public Transform[] patrolPositions;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		indexCounter = 0;
		nextMove = Time.time + waitTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (forcePushBool && Time.time > forcePushTimer) 
		{
			Debug.Log("Hej");
			forcePushBool = false;
			GameObject player = GameObject.Find("Player");
			player.rigidbody.AddForce(pushForce * transform.forward);
		}

		float step = rotationSpeed * Time.deltaTime;
		targetDirection.y = 0;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);

		//Get state from animation
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		//If in attack state, set attacking to false
		if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Attack"))
	    {
			animator.SetBool("Attacking", false);
			GameObject player = GameObject.Find("Player");
			setTargetRotationTransform(player.transform);
		}

	//Patrolling
		//If waiting
		else if (stateInfo.nameHash == Animator.StringToHash ("Base Layer.Idle") && walk == false) 
		{
			if (Time.time > nextMove) //Start moving
			{
				indexCounter++;
				if (indexCounter > patrolPositions.GetLength(0) - 1)
				{
					indexCounter = 0;
				}
				nextPosition = new Vector3(patrolPositions[indexCounter].position.x, transform.position.y, patrolPositions[indexCounter].position.z);
				animator.SetBool("Walking", true);

				targetDirection = nextPosition - transform.position;

				walk = true;
			}
		}

		else if (walk = true)
		{
			//Move toward position
			transform.position += speed * Vector3.Normalize(nextPosition - transform.position);
			
			//Arrive
			if (Vector3.Distance(nextPosition, transform.position) < 1)
			{
				nextMove = Time.time + waitTime;
				animator.SetBool("Walking", false);
				targetDirection = patrolPositions[indexCounter].forward;
				walk = false;
			}
		}


	}
	void OnCollisionEnter(Collision collision)
	{
		//On collision with player, rotate toward player and attack
		if (collision.gameObject.tag == "Player") 
		{
			animator.SetBool("Attacking", true);

			setTargetRotationTransform(collision.transform);

			forcePushTimer = Time.time + pushWaitTime;
			forcePushBool = true;
		}
	}

	void setTargetRotationTransform(Transform trform)
	{
		targetDirection = trform.position - transform.position;
	}
}
