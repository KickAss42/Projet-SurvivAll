using UnityEngine;
using System.Collections;

public class EnnemiHealth : MonoBehaviour {

    public int EnnemyHealth = 100;
    Animator anim;
    public GameObject mobGun;
    private NavMeshAgent agent;
    private GameObject player;
    

    void Start()
    {
        mobGun = GameObject.Find("mobGun");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            EnnemyHealth -= 0;
        }
    }
    void Update() {
        if (EnnemyHealth <= 0)
        {
			Destroy(mobGun);
        }
        
    }
}
