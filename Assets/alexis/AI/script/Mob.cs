using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mob : MonoBehaviour
{

    Animator anim;
    private NavMeshAgent agent;
    public bool joueurVu = false;
    private GameObject player;
    public int distance = 12;
    public GameObject mobGun;
    public GameObject bullet;
    public int power;
    public AudioClip son;
    public bool canShot = true;
    public static int vie = 5;
    public static bool isDead = false;
    public TextMesh barreVie;

    void Start()
    {
        mobGun = GameObject.Find("mobGun");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    /*void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "Player")
		{
			agent.Stop();
			anim.SetBool("isWalking",false);
			anim.SetBool("weapon",true);
			joueurVu = true;
		}
	}*/

    void Update()
    {
        string viemob = "";
        for (int i = 0; i <= vie; i++)
        {
            viemob = viemob + "-";
        }
        barreVie.text = viemob;

        if (!isDead)
        {

            if (vie <= 2)
            {
                MobMouve.danger = true;
            }

            if (Vector3.Distance(this.gameObject.transform.position, player.gameObject.transform.position) <= distance)
            {
                if (!MobMouve.danger)
                {
                    agent.Stop();
                    anim.SetBool("isWalking", false);
                    anim.SetBool("weapon", true);
                    joueurVu = true;
                }
            }

            if (joueurVu && !MobMouve.danger)
            {
                transform.LookAt(GameObject.Find("Player").transform.position);
                StartCoroutine(ShootPlayer());
            }
        }
    }

    IEnumerator ShootPlayer()
    {
        if (canShot)
        {
            canShot = false;
            GetComponent<AudioSource>().PlayOneShot(son);
            GameObject balle = (GameObject)Instantiate(bullet, mobGun.transform.position, Quaternion.identity);
            balle.name = "bullet";
            balle.GetComponent<Rigidbody>().AddForce(mobGun.transform.forward * power);
            yield return new WaitForSeconds(2);
            canShot = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            vie--;
            if (vie <= 0)
            {
                isDead = true;
                anim.SetBool("isWalking", false);
                anim.SetBool("weapon", false);
                anim.SetBool("isDead", true);
                Player.score++;
                if (!isDead)
                {
                    GameObject.Find("score").GetComponent<Text>().text = "Score : " + Player.score;
                }
                isDead = true;

                if (Application.loadedLevelName == "Jeu1")
                {
                    Application.LoadLevel("Jeu2");
                }
            }
        }
    }

}
