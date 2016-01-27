using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public int scoreValue = 50;                 // The amount added to the player's score when the enemy dies.
	public AudioClip deathClip;                 // The sound to play when the enemy dies.


	Animator anim;                              // Reference to the animator.
	AudioSource enemyAudio;                     // Reference to the audio source.
	CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
	Collision col;
	bool isDead = false;                                // Whether the enemy is dead.


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();

		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
	}

	void Update()
	{
		// If the current health is less than or equal to zero...
		if((currentHealth <= 0 ) & !isDead)
		{
			// ... the enemy is dead.
			Death ();
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Ammo") {
			currentHealth -= 25;
			enemyAudio.Play ();
		}
	}

	void Death ()
	{
		isDead = true;
		// Tell the animator that the enemy is dead.
		anim.SetTrigger ("Dead");
		anim.Play("Death_Shooting");

		// Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

		ScoreManager.score += scoreValue;
		Destroy (gameObject, 5f);
	}
}