using UnityEngine;
using System.Collections;

public class ExplosionZone : MonoBehaviour
{
    public Collider[] hitColliders;
    public float radius = 40.0f;
    public LayerMask explosionLayers;
    public float power = 100.0f;
    public float explosiveLift = 1.0f;
    public float explosiveDelay = 3.0f;
    public Rigidbody grenade;
    public GameObject explosion;

    public void Update()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(3);
        Instantiate(explosion, transform.position, transform.rotation);
        Vector3 grenadeOrigin = transform.position;
        Collider[] colliders = Physics.OverlapSphere(grenadeOrigin, radius, explosionLayers);

        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Rigidbody>() != null)
            {
                hit.GetComponent<Rigidbody>().isKinematic = false;
                hit.GetComponent<Rigidbody>().AddExplosionForce(power, grenadeOrigin, radius, explosiveLift, ForceMode.Impulse);
                hit.GetComponent<EnnemiHealth>().EnnemyHealth -= 100;
                Destroy(gameObject);
            }
        }
    }

    /*void OnCollisionEnter(Collision col)
    {

        ExplosionDamage(col.contacts[0].point);
        Destroy(gameObject);
    }*/

    /*void ExplosionDamage(Vector3 point)
    {

        hitColliders = Physics.OverlapSphere(point, radius, explosionLayers);
        foreach (Collider hCol in hitColliders)
        {
            if (hCol.GetComponent<Rigidbody>() != null)
            {
                hCol.GetComponent<Rigidbody>().isKinematic = false;
                hCol.GetComponent<Rigidbody>().AddExplosionForce(power, point, radius, explosiveLift, ForceMode.Impulse);
                hCol.GetComponent<EnnemiHealth>().EnnemyHealth -= 100;
            }
        }
    }*/
}