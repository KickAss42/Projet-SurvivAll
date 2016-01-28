using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public int scoreValue = 50;                 // The amount added to the player's score when the enemy dies.
	public AudioClip deathClip;                 // The sound to play when the enemy dies.


	Animator anim;                              // Reference to the animator.
	AudioSource enemyAudio;                     // Reference to the audio source.
	CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
	bool IsDead = false;


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();

		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Ammo") {
			currentHealth -= 25;
			enemyAudio.Play ();
		}
		if(currentHealth <= 0 & !IsDead)
		{
			// ... the enemy is dead.
			Death ();
		}
	}

	void Death ()
	{
		IsDead = !IsDead;
		anim.SetTrigger ("Dead");
		gameObject.GetComponent<ZombieAI>().enabled = false;
		gameObject.GetComponent<CharacterController>().enabled =false;

		// Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
		enemyAudio.clip = deathClip;
		enemyAudio.Play();

		ScoreManager.score += scoreValue;
		Destroy (gameObject, 3f);
	}
}