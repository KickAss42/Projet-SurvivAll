using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public int power;
    public AudioClip son;
    public int munitions = 50;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            munitions--;
            if (munitions > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(son);
                GameObject balle = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);
				balle.tag = "bullet";
                balle.GetComponent<Rigidbody>().AddForce(this.transform.forward * power);
            }
        }
    }


}