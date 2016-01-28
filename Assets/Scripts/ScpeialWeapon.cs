using UnityEngine;
using System.Collections;

public class ScpeialWeapon : MonoBehaviour
{
    public GameObject weapon;
    public ParticleSystem tracer;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnParticleCollision(GameObject col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(col, (int)0.5);
        }
    }
}
