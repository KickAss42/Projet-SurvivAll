using UnityEngine;
using System.Collections;


public class ThrowGrenades : MonoBehaviour
{
    public int ejectspeed = 15;
    public Rigidbody grenadeCasing;
    public int grenade_left = 3;
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown("g"))
        {
            if (grenade_left > 0)
            {
                grenade_left--;
                Rigidbody grenade;
                grenade = (Rigidbody)Instantiate(grenadeCasing, transform.position, transform.rotation);
                grenade.velocity = transform.TransformDirection(Vector3.forward * ejectspeed);
            }
        }
    }
}
