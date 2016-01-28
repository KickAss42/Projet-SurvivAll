using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	public float Distance;
	public Transform Target; 
	public float lookAtDistance = 20f;
	public float chaseRange = 10f;
	public float attackRange = 2.2f;
	public float moveSpeed = 3f;
	public float Damping = 6f;
	public float attackRepeatTime = 1f;

	public float TheDammage = 10f;

	private float attackTime;

	public CharacterController controller;
	public float gravity = 20f;

	private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		Findhealth ();
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(Target.position , transform.position);

		if (Distance < lookAtDistance) {
			lookAt();
		}
		if (Distance < attackRange){
			attack();
		}
		else if(Distance < chaseRange) {
			chase();
		}	
	}

	void lookAt(){
		Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);

	}

	void chase (){
		GetComponent<Animator>().Play("walk");

		moveDirection = transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection*Time.deltaTime);

	}
	void attack (){
		if(Time.time > attackTime){
			GetComponent<Animator>().Play("attack");

			Debug.Log("The enemy has attacked ");
			attackTime = Time.time + attackRepeatTime;
		}

	}

	void ApplyDammage(){
		chaseRange += 30f;
		moveSpeed+= 2f;
		lookAtDistance += 40f;
	}

	void Findhealth()
	{
		Target = GameObject.FindGameObjectWithTag("Player").transform;
	}
}
