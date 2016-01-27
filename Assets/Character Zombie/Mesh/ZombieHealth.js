#pragma strict

var ZombieHealth : int = 100;

function OnCollisionEnter (col : Collision) {
	if(col.gameObject.tag == "Ammo"){
		ZombieHealth -= 25;
	}
}

function Update (){
	if(ZombieHealth <= 0)
	{
		GetComponent.<Animator>().Play("Death_Shooting");
		gameObject.GetComponent(ZombieAI).enabled = false;
		gameObject.GetComponent(CharacterController).enabled =false;
		Dead();
	}
}

function Dead()
{
	yield WaitForSeconds(5);
	Destroy (gameObject);
}