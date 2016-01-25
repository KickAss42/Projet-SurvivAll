using UnityEngine;
using System.Collections;

public class ShotEject : MonoBehaviour {

    public Rigidbody bulletCasing;
    public int ejectSpeed = 100;
    public double fireRate = .5;
    private double nextFire = .0;
    private bool fullAuto = false;

    public int clip = 30;
    public AudioClip reloadSound;
    public AudioClip shotSound;
    public AudioClip fallSound;
    public int maxClip = 30;
    public int reserve = 300;



    void Update()
    {
        if (Input.GetButton("Fire1") & Time.time > nextFire)
        {
            if (clip > 0)
            {
                nextFire = Time.time + fireRate;
                Rigidbody bullet = Instantiate(bulletCasing, transform.position, transform.rotation) as Rigidbody;
                clip--;
                bullet.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
                GetComponent<AudioSource>().PlayOneShot(shotSound);
                GetComponent<AudioSource>().PlayOneShot(fallSound);
            }
        }

        if (Input.GetKeyDown("v"))
        {
            fullAuto = !fullAuto;
        }

        if(Input.GetKeyDown("r") & (clip != maxClip) & (reserve != 0))
        {
            GetComponent<AudioSource>().PlayOneShot(reloadSound);
            if(reserve >= maxClip - clip)
            {
                RemoveReserve();
                clip += maxClip - clip;
            }
            else
            {
                clip += reserve;
                RemoveReserve();                
            }
        }

        if (fullAuto == true)
        {
            fireRate = .1;
        }
        else
        {
            fireRate = .5;
        }
    }

    void OnGUI()
    {
        Rect rectangle = new Rect(10, 10, 130, 25);
        GUI.Box(rectangle, "Ammo : " + clip + " / " + reserve);
    }

    void RemoveReserve()
    {
        reserve -= maxClip - clip;
        if (reserve <= 0)
        {
            reserve = 0;
        }
    }
}
